using UnityEngine;

namespace CizaTool2D.EffectPlayer.Exposed
{
    public abstract class IEffectPlayer: MonoBehaviour
    {
    #region === Set ===

        public abstract void Init(IEffectPlayer    ieffectPlayer);

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
