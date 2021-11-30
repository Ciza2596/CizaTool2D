using UnityEngine;

namespace CizaTool2D.Converter
{
    public class UnityRigidbody2DConverter : MonoBehaviour, IRigidbody2D
    {
        
    #region - Base -
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        public void Init(Rigidbody2D rigidbody2D) => 
            _rigidbody2D = rigidbody2D;
        
        public bool GetIsRigidbody2DNull() {
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

        public void SetVelocity(Vector2 velocity) {
            if(GetIsRigidbody2DNull())
                return;
            
            _rigidbody2D.velocity = velocity;
        }
        
        public void AddVelocity(Vector2 addVelocity) {
            if(GetIsRigidbody2DNull())
                return;
            
            _rigidbody2D.velocity += addVelocity;
        }

        public void SetAngularVelocity(float angularVelocity) {
            if(GetIsRigidbody2DNull())
                return;
            
            _rigidbody2D.angularVelocity = angularVelocity;
        }

    #endregion

    #region - Force -

        public void AddForce(Vector2 force) {
            
            _rigidbody2D.AddForce(force);
        }

    #endregion
        
    }
}

