using System.Linq.Expressions;

namespace CizaTool2D
{
    public interface IAnimator
    {
    #region - GetIsCurrentState -
        bool GetIsCurrentState_Name(int    layer, string currentStateName);
        bool GetIsCurrentState_Tag(int layer, string stateTag);
    #endregion

        float GetCurrentNormalizedTime(int layer);

        
    #region - Play -
        void Play(string stateName, int layer, float timeScale);

        void Play(string stateName, int layer, float timeScale, float normalizedTime);
        
    #endregion

    #region - SetParam -

        void SetFloat(string paramName, float value);
        void SetInt(string paramName, int value);
        void SetBool(string paramName, bool value);
        void SetTrigger(string paramName);

    #endregion


    }
}
