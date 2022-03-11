using UnityEngine;

namespace CizaTool2D.AudioPlayer.Exposed
{
    public abstract class IAudioPlayer: MonoBehaviour
    {
    #region === Set ===

        public abstract void Init(IAudioPlayer    iaudioPlayer);
        public abstract void SetWorldVolume(float worldVolume);

    #endregion

    #region === Get === 

        public abstract bool GetIsPlaying();

    #endregion

    #region === Action ===

        public abstract void Play();

        public abstract void Stop(); 

    #endregion

    }
}
