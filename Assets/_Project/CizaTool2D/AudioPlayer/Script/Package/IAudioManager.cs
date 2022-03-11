using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CizaTool2D.AudioPlayer.Package
{
    public interface IAudioManager
    {
    #region === Get ===

        public AudioClip Clip { get; }

        public bool Loop { get; }

        public bool IsBGM { get; }

        public float Volume { get; }

        public bool IsPlaying { get; }

        public bool IsPausing { get; }


        public bool HasAudioSource { get; }

        public bool HasAudioClip { get; }

    #endregion
        
    #region === Set ===

        public void SetClip(in AudioClip clip);

        public void SetLoop(in bool loop);

        public void SetVolume(in float volume);

        public void SetIsBGM(in bool isBGM);

    #endregion
        
    #region === Action ===

        public void Play();

        public void Pause();

        public void Stop();

    #endregion

    }
}
