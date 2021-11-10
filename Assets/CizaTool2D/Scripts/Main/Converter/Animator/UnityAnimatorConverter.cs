using UnityEngine;

namespace CizaTool2D.Converter
{
    public class UnityAnimatorConverter : MonoBehaviour, IAnimator
    {
        [SerializeField] private Animator _animator;

        public string GetName(int index)
        {
            throw new System.NotImplementedException();
        }

        public float GetTime(int index)
        {
            throw new System.NotImplementedException();
        }

        public float GetNormalizeTime(int index)
        {
            throw new System.NotImplementedException();
        }

        public void Play(int index, string name, bool loop, float timeScale)
        {
            throw new System.NotImplementedException();
        }

        public void PlayAtTime(int index, float time, string name, bool loop, float timeScale)
        {
            throw new System.NotImplementedException();
        }

        public void PlayAtNormalizeTime(int index, float normalizeTime, string name, bool loop, float timeScale)
        {
            throw new System.NotImplementedException();
        }
    }
    
}
