namespace CizaTool2D.AudioPlayer
{
    public abstract class ISubAudioPlayerOperation: ISubAudioPlayer
    {
    #region === Set ===

        public abstract void SetSubAudioPlayer(ISubAudioPlayer isubAudioPlayer);
        
        public abstract void SetVolume(float volume);

        public abstract void SetIsBGM(bool isBGM);
        
        public abstract void SetLoop(bool loop);

    #endregion

    #region === Get ===

        public abstract bool GetIsPlaying();
        
        public abstract bool GetIsPausing();

    #endregion

    #region === Action ===

        public abstract void Play();

        public abstract void Pause();

        public abstract void Stop();

    #endregion

    }
}
