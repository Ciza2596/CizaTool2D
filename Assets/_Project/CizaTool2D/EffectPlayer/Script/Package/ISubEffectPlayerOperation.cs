namespace CizaTool2D.EffectPlayer.Package
{
    public abstract class ISubEffectPlayerOperation : ISubEffectPlayer
    {
    #region === Set ===

        public abstract void SetSubEffectPlayer(ISubEffectPlayer isubEffectPlayer);
        public abstract void SetLoop(bool                        loop);

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
