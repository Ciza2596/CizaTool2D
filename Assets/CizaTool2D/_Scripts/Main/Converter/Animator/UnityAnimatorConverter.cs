using UnityEngine;

namespace CizaTool2D.Converter
{
    public class UnityAnimatorConverter : MonoBehaviour, IAnimator
    {
        [SerializeField] private Animator _animator;

        public bool GetIsCurrentState(int index, string stateName) =>
            _animator.GetCurrentAnimatorStateInfo(index).IsName(stateName);

        public bool GetIsTagCurrentState(int index, string tagName) =>
            _animator.GetCurrentAnimatorStateInfo(index).IsTag(tagName);

        public bool GetIsClipNotNull(string stateName) => throw new System.NotImplementedException();
        

        public float GetCurrentNormalizeTime(int index) => _animator.GetCurrentAnimatorStateInfo(index).normalizedTime;

        public void Play(int index, string name, bool loop, float timeScale) {
            _animator.Play(name);
        }

        public void PlayAtTime(int index, float time, string name, bool loop, float timeScale) {
            throw new System.NotImplementedException();
        }

        public void PlayAtNormalizeTime(int index, float normalizeTime, string name, bool loop, float timeScale) {
            throw new System.NotImplementedException();
        }
    }
}
