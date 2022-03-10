using UnityEngine;

namespace CizaTool2D.Converter
{
    public class UnityRigidbody2DConverter : MonoBehaviour, IRigidbody2D
    {
        
    #region - Base -
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public void Init(Rigidbody2D rigidbody2D) => 
            _rigidbody2D = rigidbody2D;
        
        private bool GetIsRigidbody2DNull() {
            return Utility.Utility.GetIsObjectNull(_rigidbody2D,
                                                   () => Debug.Log("RigidBody2D is null"));
        }
        
    #endregion
        
    #region - GravityScale -

       public float GetGravityScale() {
           if(GetIsRigidbody2DNull())
               return 0;
           
           return _rigidbody2D.gravityScale;
       }

       public void SetGravityScale(float scale) {
           if(GetIsRigidbody2DNull())
               return;
           
           _rigidbody2D.gravityScale = scale;
       }

   #endregion
        
        
    #region - Velcoity -

        public Vector2 GetVelocity() {
            if(GetIsRigidbody2DNull())
                return Vector2.zero;
            
            return _rigidbody2D.velocity;
        }

        public IRigidbody2D SetVelocity(Vector2 velocity) {
            if(!GetIsRigidbody2DNull())
                _rigidbody2D.velocity = velocity;
            
            return this;
        }
        
        public IRigidbody2D AddVelocity(Vector2 addVelocity) {
            if(!GetIsRigidbody2DNull())
                _rigidbody2D.velocity += addVelocity;
            
            return this;
        }

        public IRigidbody2D SetAngularVelocity(float angularVelocity) {
            if(!GetIsRigidbody2DNull())
                _rigidbody2D.angularVelocity = angularVelocity;

            return this;
        }

    #endregion

    #region - Force -

        public IRigidbody2D AddForce(Vector2 force) {
            if(!GetIsRigidbody2DNull())
                _rigidbody2D.AddForce(force);

            return this;
        }

    #endregion
        
    }
}

