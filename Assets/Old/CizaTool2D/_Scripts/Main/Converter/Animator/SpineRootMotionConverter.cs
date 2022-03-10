using Spine.Unity;
using UnityEngine;

namespace CizaTool2D.Converter
{
    public class SpineRootMotionConverter : MonoBehaviour, IRootMotion
    {
    #region - Base -
        
        [SerializeField] private SkeletonRootMotion _rootMotion;

        public void Init(SkeletonRootMotion rootMotion) =>
            _rootMotion = rootMotion;

        public bool GetIsRootMotionNull() {
            return Utility.Utility.GetIsObjectNull(_rootMotion, () => Debug.Log("RootMotion is null"));
        }

    #endregion

        public void SetRootMotionEnable(bool enable) => _rootMotion.enabled = enable;

        public void SetPosXEnable(bool enable) => _rootMotion.enabled= enable;
    }
}
