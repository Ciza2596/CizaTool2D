﻿using UnityEngine;

namespace CizaTool2D.AudioPlayer.Package
{
    public abstract class ISubAudioPlayer: MonoBehaviour
    {
        public abstract ISubAudioPlayer GetSubAudioPlayer();

        public abstract float GetDefaultVolume();
        
        public abstract void SetDefaultVolume(float volume);
        
    }
}