using UnityEngine;

namespace CizaTool2D
{
    public interface IRigidbody2D
    {

    #region - GravityScale -

        float GetGravityScale();
        
        void SetGravityScale(float scale);

    #endregion
        
        
    #region - Velcoity -
        
        Vector2 GetVelocity();

        IRigidbody2D SetVelocity(Vector2 velocity);
        
        IRigidbody2D AddVelocity(Vector2 addVelocity);

        IRigidbody2D SetAngularVelocity(float angularVelocity);

    #endregion

    #region - Force -
        
        IRigidbody2D AddForce(Vector2 force);

    #endregion
    }
}

