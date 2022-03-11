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
        private IAudioManager audioManager;

    #region === Operation Group ===
        
        private AudioClipPlayer currentAudioClipPlayer;
        
        [PropertyOrder(20)]
        [BoxGroup("Operation")]
        [ReadOnly]
        [ShowInInspector]
        private AudioClipPlayer _CurrentAudioClipPlayer {
            get => currentAudioClipPlayer;
            set {
                currentAudioClipPlayer = value;
                if(audioManager != null){
                    audioManager.SetClip(currentAudioClipPlayer.GetClip());
                    audioManager.SetVolume(currentAudioClipPlayer.GetDefaultVolume());
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
                if(_CurrentAudioClipPlayer == null)
                    return 1;
                
                return _CurrentAudioClipPlayer.GetDefaultVolume();
            }

            set {
                _CurrentAudioClipPlayer.SetDefaultVolume(value);
                audioManager.SetVolume(_CurrentAudioClipPlayer.GetDefaultVolume() * worldVolume);
                
            }
        }

        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [GUIColor("GetPlayButtonColor")]
        [Button]
        public override void Play() {
            _CurrentAudioClipPlayer = GetRandomAudioComponent(in audioClipPlayers);
            
           if(_CurrentAudioClipPlayer != null) 
               audioManager.Play();
        }

        [PropertyOrder(34)]
        [BoxGroup("Operation")]
        [GUIColor("GetPauseButtonColor")]
        [Button]
        public void Pause() {
            audioManager.Pause();
        }

        [PropertyOrder(35)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public override void Stop() {
            audioManager.Stop();
        }

    #endregion

    #region === Settings Group ===

        [PropertyOrder(38)]
        [BoxGroup("Settings")]
        [SerializeField]
        private List<AudioClipPlayer> audioClipPlayers = new List<AudioClipPlayer>();

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
                audioManager.SetIsBGM(isBGM);
            }
        }

        [HideInInspector]
        [SerializeField]
        private bool loop;

        [PropertyOrder(50)]
        [BoxGroup("Settings")]
        [ShowInInspector]
        private bool _Loop {
            get => loop;
            set {
                loop = value;
                audioManager.SetLoop(loop);
            }
        }

    #endregion
        

    #region === Set, Set ===

        public override void Init(IAudioPlayer iaudioPlayer) {
            if(iaudioPlayer is AudioPlayer audioPlayer)
                this.audioClipPlayers = audioPlayer.audioClipPlayers;
        }

        public override void SetWorldVolume(float volume) {
            worldVolume = volume;
        }

        public override bool GetIsPlaying() {
            return audioManager.IsPlaying;
        }

    #endregion

    #region === Awake, OnValidate ===

        private void Awake() {
            CheckHasAudioManager();
        }

        private void OnValidate() {
            CheckHasAudioManager();
        }

    #endregion

    #region === Private Methods ===

    #region === CheckHasAudioManager ===

        private void CheckHasAudioManager() {

            if(audioManager != null || audioClipPlayers.Count < 1)
                return;

            _CurrentAudioClipPlayer = audioClipPlayers[0];

            audioManager = new AudioManager(gameObject.GetComponentInChildren<AudioSource>(), _CurrentAudioClipPlayer.GetClip(), loop,
                                            _DefaultVolume * worldVolume, isBGM);
        }

    #endregion
        
    #region == Random ==

        
        private AudioClipPlayer GetRandomAudioComponent(in List<AudioClipPlayer> audioClipPlayers) {

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
            if(audioManager != null){
                if(audioManager.IsPlaying)
                    return ButtonColor.GetPlayColor();

                else if(audioManager.IsPausing)
                    return ButtonColor.GetPauseColor();
            }

            return ButtonColor.GetNormalColor();
        }

        private Color GetPauseButtonColor() {
            if(audioManager != null && audioManager.IsPausing)
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
