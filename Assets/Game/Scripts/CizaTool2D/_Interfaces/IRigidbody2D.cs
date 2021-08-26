namespace CizaTools2D
{
    public interface IRigidbody2D
    {
        // Gravity
        
        public float GetGravity();
        
        public void SetGravity(float scale);
        
        
        // Velocity
        
        #region - GetVelcoity -
        
        public float GetXVelocity();
        
        public float GetYVelocity();
        
        #endregion

        #region - AddVelocity -

        public void AddXVelocity(float x);
        
        public void AddYVelocity(float y);

        #endregion


        // Force
        
        public void AddForce(float x, float y);
    }
}

