using UnityEngine;

namespace CizaTools2D
{
    public class TransformFacade : MonoBehaviour, ITransform
    {
        [SerializeField] private Transform _transform;

        // Position

        #region - GetPosition -

        public float GetXPosition()
        {
            return _transform.position.x;
        }

        public float GetYPosition()
        {
            return _transform.position.y;
        }

        public float GetZPosition()
        {
            return _transform.position.z;
        }

        #endregion

        #region - SetPosition -

        public void SetXPosition(float x)
        {
            var currentPos = _transform.position;
            _transform.position = new Vector3(x, currentPos.y, currentPos.z);
        }

        public void SetYPosition(float y)
        {
            var currentPos = _transform.position;
            _transform.position = new Vector3(currentPos.x, y, currentPos.z);
        }

        public void SetZPosition(float z)
        {
            var currentPos = _transform.position;
            _transform.position = new Vector3(currentPos.x, currentPos.y, z);
        }

        #endregion
        
        
        // LocalPosition

        #region - GetLocalPosition -

        public float GetXLocalPosition()
        {
            return _transform.localPosition.x;
        }

        public float GetYLocalPosition()
        {
            return _transform.localPosition.y;
        }

        public float GetZLocalPosition()
        {
            return _transform.localPosition.z;
        }

        #endregion

        #region - SetLocalPosition -

        public void SetXLocalPosition(float x)
        {
            var currentLocalPos = _transform.localPosition;
            _transform.localPosition = new Vector3(x, currentLocalPos.y, currentLocalPos.z);
        }
                                                      
        public void SetYLocalPosition(float y)
        {
            var currentLocalPos = _transform.localPosition;
            _transform.localPosition = new Vector3(currentLocalPos.x, y, currentLocalPos.z);
        }

        public void SetZLocalPosition(float z)
        {
            var currentLocalPos = _transform.localPosition;
            _transform.localPosition = new Vector3(currentLocalPos.x, currentLocalPos.y, z);
        }

        #endregion


        // Rotation

        #region - GetRotation -

        public float GetXRotation()
        {
            return _transform.eulerAngles.x;
        }

        public float GetYRotation()
        {
            return _transform.eulerAngles.y;
        }

        public float GetZRotation()
        {
            return _transform.eulerAngles.z;
        }

        #endregion

        #region - SetRotation -

        public void SetXEulerRotation(float x)
        {
            var currentEulerRotation = _transform.eulerAngles;
            _transform.eulerAngles = new Vector3(x, currentEulerRotation.y, currentEulerRotation.z);
        }

        public void SetYEulerRotation(float y)
        {
            var currentEulerRotation = _transform.eulerAngles;
            _transform.eulerAngles = new Vector3(currentEulerRotation.x, y, currentEulerRotation.z);
        }

        public void SetZEulerRotation(float z)
        {
            var currentEulerRotation = _transform.eulerAngles;
            _transform.eulerAngles = new Vector3(currentEulerRotation.x, currentEulerRotation.y, z);
        }

        #endregion


        // LocalScale

        #region - GetLocalScale -

        public float GetXLocalScale()
        {
            return _transform.localScale.x;
        }

        public float GetYLocalScale()
        {
            return _transform.localScale.y;
        }

        public float GetZLocalScale()
        {
            return _transform.localScale.z;
        }

        #endregion

        #region - SetLocalScale -

        public void SetXLocalScale(float x)
        { 
            var currentLocalScale = _transform.localScale;
            _transform.localScale = new Vector3(x, currentLocalScale.y, currentLocalScale.z);
        }

        public void SetYLocalScale(float y)
        {
            var currentLocalScale = _transform.localScale;
            _transform.localScale = new Vector3(currentLocalScale.x, y, currentLocalScale.z);
        }

        public void SetZLocalScale(float z)
        {
            var currentLocalScale = _transform.localScale;
            _transform.localScale = new Vector3(currentLocalScale.x, currentLocalScale.y, z);
        }

        #endregion
    }
}