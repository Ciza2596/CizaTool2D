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

        void SetVelocity(Vector2 velocity);
        
        void AddVelocity(Vector2 addVelocity);

        void SetAngularVelocity(float angularVelocity);

    #endregion

    #region - Force -
        
        void AddForce(Vector2 force);

    #endregion
    }
}

