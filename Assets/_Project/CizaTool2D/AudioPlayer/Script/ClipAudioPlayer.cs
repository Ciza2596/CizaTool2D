using CizaTool2D.AudioPlayer.Package;
using CizaTool2D.Utility.Editor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CizaTool2D.AudioPlayer
{
    public class ClipAudioPlayer : ISubAudioPlayerOperation
    {
        private ClipManager clipManager;

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
                clipManager.SetVolume(defaultVolume * worldVolume);
            }
        }

        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [GUIColor("GetPlayButtonColor")]
        [Button]
        public override void Play() {
            clipManager.Play();
        }

        [PropertyOrder(34)]
        [BoxGroup("Operation")]
        [GUIColor("GetPauseButtonColor")]
        [Button]
        public override void Pause() {
            clipManager.Pause();
        }

        [PropertyOrder(35)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public override void Stop() {
            clipManager.Stop();
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
                clipManager.SetClip(clip);
            }
        }

    #endregion

    #region === Set, Get ===

    #region ===  ISubAudioPlayer ===

        public override ISubAudioPlayer GetSubAudioPlayer() {
            return this;
        }

        public override float GetDefaultVolume() {
            return defaultVolume;
        }

        public override void SetDefaultVolume(float volume) {
            _DefaultVolume = volume;
        }

    #endregion

    #region === ISubAudioPlayerOperation ===

        public override void SetSubAudioPlayer(ISubAudioPlayer isubAudioPlayer) {
            if(isubAudioPlayer is ClipAudioPlayer clipAudioPlayer)
                _Clip = clipAudioPlayer._Clip;
        }

        public override void SetVolume(float volume) {
            clipManager.SetVolume(volume);
        }

        public override void SetIsBGM(bool isBGM) {
            clipManager.SetIsBGM(isBGM);
        }

        public override void SetLoop(bool loop) {
            clipManager.SetLoop(loop);
        }

        public override bool GetIsPlaying() {
            return clipManager.IsPlaying;
        }

        public override bool GetIsPausing() {
            return clipManager.IsPausing;
        }

    #endregion

    #endregion

    #region === Awake, OnValidate ===

        private void Awake() {
            CheckAudioManager();
        }

        private void OnValidate() {
            CheckAudioManager();
        }

    #endregion

    #region === Private Methods ===

        private void CheckAudioManager() {
            if(clipManager != null)
                return;

            clipManager = new ClipManager(gameObject.GetComponentInChildren<AudioSource>(), clip, false,
                                            defaultVolume * worldVolume, false);
        }

    #region == DrawButton ==

        private Color GetPlayButtonColor() {
            if(clipManager != null){
                if(clipManager.IsPlaying)
                    return ButtonColor.GetPlayColor();

                else if(clipManager.IsPausing)
                    return ButtonColor.GetPauseColor();
            }

            return ButtonColor.GetNormalColor();
        }

        private Color GetPauseButtonColor() {
            if(clipManager != null && clipManager.IsPausing)
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
