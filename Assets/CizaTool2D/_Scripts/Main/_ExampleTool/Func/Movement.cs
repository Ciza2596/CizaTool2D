using UnityEngine;

namespace CizaTool2D.ExampleTool.Func
{
    public class Movement
    {
        public float   Speed     { get; private set; }
        public Vector2 Direction { get; private set; }

        private ITransform _transform;

        public Movement SetTransform(ITransform transform) {
            _transform = transform;
            return this;
        }

        public Movement SetSpeed(float speed) {
            Speed = speed;
            return this;
        }

        public void  Update() {
            if(Input.GetKey(KeyCode.W) 
               || Input.GetKey(KeyCode.UpArrow)){
                 Direction = Vector2.up;
            }else if(Input.GetKey(KeyCode.A) 
                     || Input.GetKey(KeyCode.LeftArrow)){
                Direction = Vector2.left;
            }else if(Input.GetKey(KeyCode.S) 
                     || Input.GetKey(KeyCode.RightArrow)){
                Direction = Vector2.down;
            }else if(Input.GetKey(KeyCode.D) 
                     || Input.GetKey(KeyCode.DownArrow)){
                Direction = Vector2.right;
            }else{
                Direction  = Vector2.zero; 
            }

            Moving(Direction);
        }

        private void Moving(Vector2 direction) {
            
            _transform.SetPosition(_transform.GetPosition() 
                                   + (Vector3)direction * Speed * Time.deltaTime);
        }
    }
}
