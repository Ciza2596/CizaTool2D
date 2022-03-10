using System.Collections.Generic;
using UnityEngine;

namespace CizaTool2D.Scene.Background
{
    public class Parallax
    {
    #region = Private Variables =
        
        private Transform                    _camera;
        private Vector2                      _sceneCenter;
        private List<LayerData> _layers;

        private BaseParallax _base;

    #endregion

    #region = Constructor =

        public Parallax() {
            _base = new BaseParallax();
        }
        
        public Parallax(Transform                    camera,
                        Vector2                      sceneCenter,
                        List<LayerData> layers) {
            _base        = new BaseParallax();

            this.SetCamera(camera)
                .SetSceneCenter(sceneCenter)
                .SetLayers(layers)
                .InitLayers();
        }

    #endregion

    #region = Public Methods =

        public Parallax SetCamera(Transform camera) {
            _camera = camera;
            return this;
        }
        
        public Parallax SetSceneCenter(Vector2 sceneCenter) {
            _sceneCenter = sceneCenter;
            return this;
        }
        
        public Parallax SetLayers(List<LayerData> layers) {
            _layers = layers;
            return this;
        }
        
        public Parallax InitLayers() {
            _base.InitLayers(_layers);
            return this;
        }

        public Parallax UpdateLayers() {
            _base.UpdateLayers(_camera.position, 
                               _sceneCenter,
                               _layers);
            return this;
        }

    #endregion
    }
}
