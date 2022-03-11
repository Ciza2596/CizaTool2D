using UnityEngine;

namespace CizaTool2D.AudioPlayer.Package
{
    public class AudioManager : IAudioManager
    {
    #region === Constroctor ===

        public AudioManager(AudioSource audioSource,
                            AudioClip   currentClip,
                            bool        loop,
                            float       volume,
                            bool        isBGM) {
            if(audioSource == null)
                Debug.Log("Loading audioSource failed.");

            this.audioSource              = audioSource;
            this.audioSource.clip         = currentClip;
            this.audioSource.loop         = loop;
            this.audioSource.volume       = volume;
            this.audioSource.spatialBlend = isBGM ? 0 : 1;
        }

    #endregion

        private AudioSource audioSource;

    #region === Get ===

        public AudioClip Clip {
            get {
                if(!HasAudioSource)
                    return null;
                return audioSource.clip;
            }
        }

        public bool Loop {
            get {
                if(!HasAudioSource)
                    return false;
                return audioSource.loop;
            }
        }

        public bool IsBGM {
            get {
                if(!HasAudioSource)
                    return false;
                return audioSource.spatialBlend == 1;
            }
        }

        public float Volume {
            get {
                if(!HasAudioSource)
                    return 0;
                return audioSource.volume;
            }
        }

        public bool IsPlaying {
            get {
                if(!HasAudioSource)
                    return false;
                return audioSource.isPlaying;
            }
        }

        public bool IsPausing { get; private set; }


        public bool HasAudioSource {
            get {
                if(audioSource != null)
                    return true;

                Debug.Log("Hasnt Audio Source");
                return false;
            }
        }

        public bool HasAudioClip {
            get {
                if(Clip != null)
                    return true;

                Debug.Log("Hasnt Audio Clip");
                return false;
            }
        }

    #endregion

    #region === Set ===

        public void SetClip(in AudioClip clip) {
            audioSource.clip = clip;
        }

        public void SetLoop(in bool loop) {
            audioSource.loop = loop;
        }

        public void SetVolume(in float volume) {
            audioSource.volume = volume;
        }

        public void SetIsBGM(in bool isBGM) {
            audioSource.spatialBlend = isBGM ? 0 : 1;
        }

    #endregion

    #region === Action ===

        public void Play() {
            if(!HasAudioSource || !HasAudioClip)
                return;

            IsPausing = false;
            audioSource.Play();
        }

        public void Pause() {
            if(!HasAudioSource || !IsPlaying)
                return;

            audioSource.Pause();
            IsPausing = true;
        }

        public void Stop() {
            if(!HasAudioSource)
                return;

            audioSource.Stop();
            IsPausing = false;
        }

    #endregion
    }
}
