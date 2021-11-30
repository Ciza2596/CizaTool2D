using UnityEngine;

namespace CizaTool2D.Converter
{
    public class UnityAnimatorConverter : MonoBehaviour, IAnimator
    {
    #region - Base -
        
        [SerializeField] private Animator _animator;

        public void Init(Animator animator) =>
            _animator = animator;

        public bool GetIsAnimatorNull() {
            return Utility.Utility.GetIsObjectNull(_animator, () => Debug.Log("Animator is null"));
        }

    #endregion


    #region - GetIsCurrentState -

        public bool GetIsCurrentState_Name(int layer, string stateName) {
            if(GetIsAnimatorNull())
                return false;
            
            return  _animator.GetCurrentAnimatorStateInfo(layer).IsName(stateName);
        }

        public bool GetIsCurrentState_Tag(int layer, string stateTag) {
            if(GetIsAnimatorNull())
                return false;
            
           return _animator.GetCurrentAnimatorStateInfo(layer).IsTag(stateTag);
        }

    #endregion

        public float GetCurrentNormalizedTime(int layer) {
            if(GetIsAnimatorNull())
                return 0;
            
            return _animator.GetCurrentAnimatorStateInfo(layer).normalizedTime;
        }

    #region - Play -

        public void Play(string stateName) {
            if(GetIsAnimatorNull())
                return;
            
            _animator.Play(stateName);
        }
        
        public void Play(string stateName, int layer, float timeScale) {
            if(GetIsAnimatorNull())
                return;
            
            SetFloat($"TimeScale_{layer}", timeScale);
            _animator.Play(stateName);
        }

        public void Play(string stateName, int layer, float timeScale, float normalizedTime) {
            if(GetIsAnimatorNull())
                return;
            
            SetFloat($"TimeScale_{layer}", timeScale);
            _animator.Play(stateName, layer, normalizedTime);
        }

    #endregion
        
    #region - SetParam -

        public void SetFloat(string paramName, float value) {
            if(GetIsAnimatorNull())
                return;
            
            _animator.SetFloat(paramName, value);
        }
        public void SetInt(string paramName, int value) {
            if(GetIsAnimatorNull())
                return;
            
            _animator.SetInteger(paramName, value);
        }

        public void SetBool(string paramName, bool value) {
            if(GetIsAnimatorNull())
                return;
            
            _animator.SetBool(paramName, value);
        }

        public void SetTrigger(string paramName) {
            if(GetIsAnimatorNull())
                return;
            
            _animator.SetTrigger(paramName);
        }

    #endregion
    }
}
