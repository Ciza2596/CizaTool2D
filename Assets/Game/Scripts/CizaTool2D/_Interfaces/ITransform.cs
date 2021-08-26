namespace CizaTools2D
{
    public interface ITransform
    {
        // Position

        #region - GetPosition -

        public float GetXPosition();

        public float GetYPosition();

        public float GetZPosition();

        #endregion
        
        #region - SetPosition -

        public void SetXPosition(float x);

        public void SetYPosition(float y);

        public void SetZPosition(float z);

        #endregion

        
        // LocalPosition

        #region - GetLocalPosition -

        public float GetXLocalPosition();

        public float GetYLocalPosition();

        public float GetZLocalPosition();

        #endregion

        #region - SetLocalPosition -

        public void SetXLocalPosition(float x);

        public void SetYLocalPosition(float y);

        public void SetZLocalPosition(float z);

        #endregion
        
        
        // Rotation
        
        #region - GetRotation -

        public float GetXRotation();

        public float GetYRotation();

        public float GetZRotation();

        #endregion
        
        #region - SetRotation -

        public void SetXEulerRotation(float x);

        public void SetYEulerRotation(float y);

        public void SetZEulerRotation(float z);

        #endregion
        
        
        // LocalScale
        
        #region - GetLocalScale -

        public float GetXLocalScale();

        public float GetYLocalScale();

        public float GetZLocalScale();

        #endregion

        #region - SetLocalScale -

        public void SetXLocalScale(float x);

        public void SetYLocalScale(float y);

        public void SetZLocalScale(float z);

        #endregion
        
    }   
}
    
