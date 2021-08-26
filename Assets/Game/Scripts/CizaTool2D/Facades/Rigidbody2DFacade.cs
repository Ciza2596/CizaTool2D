using UnityEngine;

namespace CizaTools2D
{
    public class Rigidbody2DFacade : MonoBehaviour, IRigidbody2D
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        
        // Gravity

        public float GetGravity()
        {
            return _rigidbody2D.gravityScale;
        }

        public void SetGravity(float scale)
        {
            _rigidbody2D.gravityScale = scale;
        }


        // Velocity
        
        #region - GetVelcoity -

        public float GetXVelocity()
        {
            return _rigidbody2D.velocity.x;
        }

        public float GetYVelocity()
        {
            return _rigidbody2D.velocity.y;
        }

        #endregion

        #region - AddVelocity -

        public void AddXVelocity(float x)
        {
            _rigidbody2D.velocity += new Vector2(x, 0);
        }

        public void AddYVelocity(float y)
        {
            _rigidbody2D.velocity += new Vector2(0, y);
        }

        #endregion


        // Force

        public void AddForce(float x, float y)
        {
            _rigidbody2D.AddForce(new Vector2(x,y));
        }
    }
}

