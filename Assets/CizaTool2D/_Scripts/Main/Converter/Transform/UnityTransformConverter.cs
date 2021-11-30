using UnityEngine;

namespace CizaTool2D.Converter
{
    public class UnityTransformConverter : MonoBehaviour, ITransform
    {
    #region - Base -

        [SerializeField] private Transform _transform;

        public void Init(Transform transform) =>
            _transform = transform;

        public bool GetIsTransformNull() {
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

        public void SetPosition(Vector3 position) {
            if(GetIsTransformNull())
                return;

            _transform.position = position;
        }

    #endregion

    #region - LocalPosition -

        public Vector3 GetLocalPosition() {
            if(GetIsTransformNull())
                return Vector3.zero;

            return _transform.localPosition;
        }

        public void SetLocalPosition(Vector3 localPosition) {
            if(GetIsTransformNull())
                return;

            _transform.localPosition = localPosition;
        }

    #endregion

    #region - EulerAngles -

        public Vector3 GetEulerAngles() {
            if(GetIsTransformNull())
                return Vector3.zero;

            return _transform.eulerAngles;
        }

        public void SetEulerAngles(Vector3 eulerAngles) {
            if(GetIsTransformNull())
                return;

            _transform.eulerAngles = eulerAngles;
        }

    #endregion

    #region - LocalScale -

        public Vector3 GetLocalScale() {
            if(GetIsTransformNull())
                return Vector3.zero;

            return _transform.localScale;
        }

        public void SetLocalScale(Vector3 localScale) {
            if(GetIsTransformNull())
                return;

            _transform.localScale = localScale;
        }

    #endregion
    }
}
