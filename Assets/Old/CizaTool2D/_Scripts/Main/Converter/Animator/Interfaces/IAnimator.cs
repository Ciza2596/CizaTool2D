
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
        IAnimator Play(string stateName);
        IAnimator Play(string stateName, int layer, float timeScale);

        IAnimator Play(string stateName, int layer, float timeScale, float normalizedTime);
        
    #endregion

    #region - SetParam -

        IAnimator SetFloat(string   paramName, float value);
        IAnimator SetInt(string     paramName, int   value);
        IAnimator SetBool(string    paramName, bool  value);
        IAnimator SetTrigger(string paramName);

    #endregion


    }
}
