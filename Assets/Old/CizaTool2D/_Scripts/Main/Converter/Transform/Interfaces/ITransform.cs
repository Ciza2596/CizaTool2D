using UnityEngine;

namespace CizaTool2D
{
    public interface ITransform
    {

    #region - Position -

        Vector3 GetPosition();
        
        ITransform SetPosition(Vector3 position);

    #endregion

    #region - LocalPosition -

        Vector3 GetLocalPosition();
        
        ITransform SetLocalPosition(Vector3 localPosition);

    #endregion
        
    #region - EulerAngles -

        Vector3 GetEulerAngles();

        ITransform SetEulerAngles(Vector3 eulerAngles);

    #endregion

    #region - LocalScale -

        Vector3 GetLocalScale();

        ITransform SetLocalScale(Vector3 localScale);

    #endregion
    }
}
