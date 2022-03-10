using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CizaTool2D.Scene.Background
{
    public class BackgroundParallax : MonoBehaviour
    {
    #region = Private Variables =
        
        [BoxGroup("CameraAndSceneCenter")]
        [SerializeField] private Transform    _camera;
        [BoxGroup("CameraAndSceneCenter")]
        [SerializeField] private Vector2      _sceneCenter;

        [Space] [SerializeField] [TableList] private List<LayerData> _layers;

        private Parallax _parallax;

    #endregion

    #region = Unity Event =

        void OnEnable() {
            enabled = (_layers != null);
            
            _parallax = new Parallax(_camera,
                                     _sceneCenter,
                                     _layers);
        }

        void Update() => _parallax.UpdateLayers();

    #endregion
        
    }
}
