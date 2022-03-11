using CizaTool2D.AudioPlayer.Package;
using CizaTool2D.Utility.Editor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CizaTool2D.AudioPlayer
{
    public class AudioClipPlayer : MonoBehaviour
    {
        private IAudioManager audioManager;

    #region === Operation Group ===

        [PropertyOrder(26)]
        [BoxGroup("Operation")]
        [ReadOnly]
        [PropertyRange(0, 1)]
        [SerializeField]
        private float worldVolume = 0.7f;

        [HideInInspector]
        [SerializeField]
        private float defaultVolume = 1;

        [PropertyOrder(28)]
        [BoxGroup("Operation")]
        [PropertyRange(0, 1)]
        [ShowInInspector]
        private float _DefaultVolume {
            get { return defaultVolume; }

            set {
                defaultVolume = value;
                audioManager.SetVolume(defaultVolume * worldVolume);
            }
        }

        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [GUIColor("GetPlayButtonColor")]
        [Button]
        public void Play() {
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
        public void Stop() {
            audioManager.Stop();
        }

    #endregion

    #region === Settings Group ===

        
        [HideInInspector]
        [SerializeField]
        private AudioClip clip;

        [PropertyOrder(38)]
        [BoxGroup("Settings")]
        [ShowInInspector]
        private AudioClip _Clip {
            get => clip;
            set {
                clip = value;
                audioManager.SetClip(clip);
            }
        }

    #endregion

    #region === Set, Get ===

        public void SetDefaultVolume(float defaultVolume) {
             _DefaultVolume = defaultVolume;
        }
        
        public AudioClip GetClip() {
            return clip;
        }
        
        public float GetDefaultVolume() {
            return defaultVolume;
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

        private void CheckHasAudioManager() {
            if(audioManager != null)
                return;
            
            audioManager = new AudioManager(gameObject.GetComponentInChildren<AudioSource>(), clip,false,defaultVolume * worldVolume, false);
        }

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
