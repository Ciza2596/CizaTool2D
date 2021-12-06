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

        public IAnimator Play(string stateName) {
            if(!GetIsAnimatorNull())
                _animator.Play(stateName);
            return this;
        }
        
        public IAnimator Play(string stateName, int layer, float timeScale) {
            if(!GetIsAnimatorNull()){
                SetFloat($"TimeScale_{layer}", timeScale);
                _animator.Play(stateName);
            }
            return this;
        }

        public IAnimator Play(string stateName, int layer, float timeScale, float normalizedTime) {
            if(!GetIsAnimatorNull()){
                SetFloat($"TimeScale_{layer}", timeScale);
                _animator.Play(stateName, layer, normalizedTime);
            }
            return this;
        }

    #endregion
        
    #region - SetParam -

        public IAnimator SetFloat(string paramName, float value) {
            if(!GetIsAnimatorNull())
                _animator.SetFloat(paramName, value);
                
            return this;
        }
        public IAnimator SetInt(string paramName, int value) {
            if(!GetIsAnimatorNull())
                _animator.SetInteger(paramName, value);
            
            return this;
        }

        public IAnimator SetBool(string paramName, bool value) {
            if(!GetIsAnimatorNull())
                _animator.SetBool(paramName, value);

            return this;
        }

        public IAnimator SetTrigger(string paramName) {
            if(!GetIsAnimatorNull())
                _animator.SetTrigger(paramName);
            
            return this;
        }

    #endregion
    }
}
