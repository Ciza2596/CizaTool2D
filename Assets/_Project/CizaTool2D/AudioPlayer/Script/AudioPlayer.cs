using System.Collections.Generic;
using CizaTool2D.AudioPlayer.Exposed;
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
        
        [PropertyOrder(20)]
        [BoxGroup("Operation")]
        [ReadOnly]
        [ShowInInspector]
        private ISubAudioPlayer CurrentSubAudioPlayer {
            get => currentSubAudioPlayer;
            set {
                currentSubAudioPlayer = value;
                if(operateSubAudioPlayerOperation != null){
                    operateSubAudioPlayerOperation.SetSubAudioPlayer(currentSubAudioPlayer.GetSubAudioPlayer());
                    operateSubAudioPlayerOperation.SetVolume(currentSubAudioPlayer.GetDefaultVolume() * worldVolume);
                }
            }
        }


        [PropertyOrder(26)]
        [BoxGroup("Operation")]
        [PropertySpace]
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
                if(CurrentSubAudioPlayer == null)
                    return 1;
                
                return CurrentSubAudioPlayer.GetDefaultVolume();
            }

            set {
                CurrentSubAudioPlayer.SetDefaultVolume(value);
                operateSubAudioPlayerOperation.SetVolume(CurrentSubAudioPlayer.GetDefaultVolume() * worldVolume);
                
            }
        }

        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [GUIColor("GetPlayButtonColor")]
        [Button]
        public override void Play() {
            CurrentSubAudioPlayer = GetRandomComponent(in subAudioPlayers);
            
           if(CurrentSubAudioPlayer != null) 
               operateSubAudioPlayerOperation.Play();
        }

        [PropertyOrder(34)]
        [BoxGroup("Operation")]
        [GUIColor("GetPauseButtonColor")]
        [Button]
        public void Pause() {
            operateSubAudioPlayerOperation.Pause();
        }

        [PropertyOrder(35)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public override void Stop() {
            operateSubAudioPlayerOperation.Stop();
        }

    #endregion

    #region === Settings Group ===
        
        [PropertyOrder(37)]
        [BoxGroup("Settings")]
        [SerializeField]
        private ISubAudioPlayerOperation operateSubAudioPlayerOperation;
        
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
                operateSubAudioPlayerOperation.SetIsBGM(isBGM);
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
                operateSubAudioPlayerOperation.SetLoop(loop);
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
                subAudioPlayers = audioPlayer.subAudioPlayers;
                if(subAudioPlayers.Count > 0 && subAudioPlayers[0] is AudioClipPlayer)
                    operateSubAudioPlayerOperation = GetComponentInChildren<AudioClipPlayer>();
            }
        }

        public override void SetWorldVolume(float volume) {
            worldVolume = volume;
        }

        public override bool GetIsPlaying() {
            return operateSubAudioPlayerOperation.GetIsPlaying();
        }

    #endregion

    #region === Private Methods ===

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
            if(operateSubAudioPlayerOperation != null){
                if(operateSubAudioPlayerOperation.GetIsPlaying())
                    return ButtonColor.GetPlayColor();

                else if(operateSubAudioPlayerOperation.GetIsPausing())
                    return ButtonColor.GetPauseColor();
            }

            return ButtonColor.GetNormalColor();
        }

        private Color GetPauseButtonColor() {
            if(operateSubAudioPlayerOperation != null && operateSubAudioPlayerOperation.GetIsPausing())
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
