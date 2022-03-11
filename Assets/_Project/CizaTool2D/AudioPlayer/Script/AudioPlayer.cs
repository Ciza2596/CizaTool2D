using System.Collections.Generic;
using CizaTool2D.AudioPlayer.Exposed;
using CizaTool2D.AudioPlayer.Package;
using CizaTool2D.Utility.Editor;
using CizaTool2D.Utility.RandomNumber;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CizaTool2D.AudioPlayer
{
    public class AudioPlayer : IAudioPlayer
    {
        private IRandomNumber randomNumber = new NormalRandomNumber();

    #region === Operation Group ===
        
        private ISubAudioPlayer currentSubAudioPlayer;
        
        [PropertyOrder(15)]
        [BoxGroup("Operation")]
        [ReadOnly]
        [SerializeField]
        private ISubAudioPlayerOperation subAudioPlayerOperation;
        
        [PropertyOrder(20)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        private ISubAudioPlayer _CurrentSubAudioPlayer {
            get => currentSubAudioPlayer;
            set {
                currentSubAudioPlayer = value;
                
                CheckSubAudioPlayerOperation();
                
                if(subAudioPlayerOperation != null){
                    subAudioPlayerOperation.SetSubAudioPlayer(currentSubAudioPlayer.GetSubAudioPlayer());
                    subAudioPlayerOperation.SetVolume(currentSubAudioPlayer.GetDefaultVolume() * worldVolume);
                    _IsBGM = isBGM;
                    _Loop = loop;
                }
            }
        }


        [PropertyOrder(26)]
        [BoxGroup("Operation")]
        [ReadOnly]
        [PropertyRange(0, 1)]
        [SerializeField]
        private float worldVolume = 0.7f;

        [PropertyOrder(28)]
        [BoxGroup("Operation")]
        [PropertyRange(0, 1)]
        [ShowInInspector]
        private float _DefaultVolume {
            get {
                if(_CurrentSubAudioPlayer == null)
                    return 1;
                
                return _CurrentSubAudioPlayer.GetDefaultVolume();
            }

            set {
                _CurrentSubAudioPlayer.SetDefaultVolume(value);
                subAudioPlayerOperation.SetVolume(_CurrentSubAudioPlayer.GetDefaultVolume() * worldVolume);
                
            }
        }

        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [GUIColor("GetPlayButtonColor")]
        [Button]
        public override void Play() {
            _CurrentSubAudioPlayer = GetRandomComponent(in subAudioPlayers);

            if(_CurrentSubAudioPlayer != null) 
               subAudioPlayerOperation.Play();
        }

        [PropertyOrder(34)]
        [BoxGroup("Operation")]
        [GUIColor("GetPauseButtonColor")]
        [Button]
        public void Pause() {
            subAudioPlayerOperation.Pause();
        }

        [PropertyOrder(35)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public override void Stop() {
            subAudioPlayerOperation.Stop();
        }

    #endregion

    #region === Settings Group ===

        [HideInInspector]
        [SerializeField]
        private bool isBGM;

        [PropertyOrder(39)]
        [BoxGroup("Settings")]
        [ShowInInspector]
        private bool _IsBGM {
            get => isBGM;
            set {
                isBGM = value;
                subAudioPlayerOperation.SetIsBGM(isBGM);
            }
        }

        [HideInInspector]
        [SerializeField]
        private bool loop;

        [PropertyOrder(45)]
        [BoxGroup("Settings")]
        [ShowInInspector]
        private bool _Loop {
            get => loop;
            set {
                loop = value;
                subAudioPlayerOperation.SetLoop(loop);
            }
        }

        [PropertyOrder(50)]
        [BoxGroup("Settings")]
        [SerializeField]
        private List<ISubAudioPlayer> subAudioPlayers = new List<ISubAudioPlayer>();

    #endregion
        

    #region === Set, Set ===

        public override void Init(IAudioPlayer iaudioPlayer) {
            if(iaudioPlayer is AudioPlayer audioPlayer){
                isBGM           = audioPlayer.isBGM;
                loop            = audioPlayer.loop;
                
                subAudioPlayers = audioPlayer.subAudioPlayers;
            }
        }

        public override void SetWorldVolume(float volume) {
            worldVolume = volume;
        }

        public override bool GetIsPlaying() {
            return subAudioPlayerOperation.GetIsPlaying();
        }

    #endregion

    #region === Private Methods ===
        
    #region == CheckSubAudioPlayerOperation(如果新增子類，只需改動這裡) ==
        
        private void CheckSubAudioPlayerOperation() {
            if(_CurrentSubAudioPlayer is ClipAudioPlayer && !(subAudioPlayerOperation is ClipAudioPlayer)){
                subAudioPlayerOperation = GetComponentInChildren<ClipAudioPlayer>();
            }
        }
        
    #endregion

    #region == Random ==

        
        private T GetRandomComponent<T>(in List<T> audioClipPlayers) where T: Component {

            var count = audioClipPlayers.Count;
            if(count == 1){
                return audioClipPlayers[0];
            }
            else if(count == 2){
                return audioClipPlayers[randomNumber.GetRandomNumberForTwo()];
            }
            else if(count >= 3){
                return audioClipPlayers[randomNumber.GetRandomNumberForMoreThree(count)];
            }
            else{
                return null;
            }
        }

    #endregion
        

    #region == DrawButton ==

        private Color GetPlayButtonColor() {
            if(subAudioPlayerOperation != null){
                if(subAudioPlayerOperation.GetIsPlaying())
                    return ButtonColor.GetPlayColor();

                else if(subAudioPlayerOperation.GetIsPausing())
                    return ButtonColor.GetPauseColor();
            }

            return ButtonColor.GetNormalColor();
        }

        private Color GetPauseButtonColor() {
            if(subAudioPlayerOperation != null && subAudioPlayerOperation.GetIsPausing())
                return ButtonColor.GetPauseColor();

            return ButtonColor.GetNormalColor();
        }

        private Color GetNormalColor() {
            return ButtonColor.GetNormalColor();
        }

    #endregion

    #endregion
    }
}
