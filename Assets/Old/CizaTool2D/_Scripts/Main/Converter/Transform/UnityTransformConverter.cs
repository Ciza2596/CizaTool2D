using UnityEngine;

namespace CizaTool2D.Converter
{
    public class UnityTransformConverter : MonoBehaviour, ITransform
    {
    #region - Base -

        [SerializeField] private Transform _transform;

        public void Init(Transform transform) =>
            _transform = transform;

        private bool GetIsTransformNull() {
            return Utility.Utility.GetIsObjectNull(_transform,
                                                   () => Debug.Log("Transform is null"));
        }

    #endregion

    #region - Position -

        public Vector3 GetPosition() {
            if(GetIsTransformNull())
                return Vector3.zero;

            return _transform.position;
        }

        public ITransform SetPosition(Vector3 position) {
            if(!GetIsTransformNull())
                _transform.position = position;
            
            return this;
        }

    #endregion

    #region - LocalPosition -

        public Vector3 GetLocalPosition() {
            if(GetIsTransformNull())
                return Vector3.zero;

            return _transform.localPosition;
        }

        public ITransform SetLocalPosition(Vector3 localPosition) {
            if(!GetIsTransformNull())
                _transform.localPosition = localPosition;

            return this;
        }

    #endregion

    #region - EulerAngles -

        public Vector3 GetEulerAngles() {
            if(GetIsTransformNull())
                return Vector3.zero;

            return _transform.eulerAngles;
        }

        public ITransform SetEulerAngles(Vector3 eulerAngles) {
            if(!GetIsTransformNull())
                _transform.eulerAngles = eulerAngles;
            
            return this;
        }

    #endregion

    #region - LocalScale -

        public Vector3 GetLocalScale() {
            if(GetIsTransformNull())
                return Vector3.zero;

            return _transform.localScale;
        }

        public ITransform SetLocalScale(Vector3 localScale) {
            if(!GetIsTransformNull())
                _transform.localScale = localScale;

            return this;
        }

    #endregion
    }
}
