using UnityEngine;

namespace CizaTool2D
{
    public interface ITransform
    {

    #region - Position -

        Vector3 GetPosition();
        
        void SetPosition(Vector3 position);

    #endregion

    #region - LocalPosition -

        Vector3 GetLocalPosition();
        
        void SetLocalPosition(Vector3 localPosition);

    #endregion
        
    #region - EulerAngles -

        Vector3 GetEulerAngles();

        void SetEulerAngles(Vector3 eulerAngles);

    #endregion

    #region - LocalScale -

        Vector3 GetLocalScale();

        void SetLocalScale(Vector3 localScale);

    #endregion
    }
}
