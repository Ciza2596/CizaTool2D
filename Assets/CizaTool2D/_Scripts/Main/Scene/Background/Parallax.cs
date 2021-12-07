using System.Collections.Generic;
using UnityEngine;

namespace CizaTool2D.Scene.Background
{
    public class Parallax
    {
    #region = Private Variables =
        
        private Transform                    _camera;
        private Vector2                      _sceneCenter;
        private List<BaseParallax.LayerData> _layers;

        private BaseParallax _func;

    #endregion

    #region = Constructor =

        public Parallax() {
            _func = new BaseParallax();
        }
        
        public Parallax(Transform                    camera,
                        Vector2                      sceneCenter,
                        List<BaseParallax.LayerData> layers) {
            _func        = new BaseParallax();

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
        
        public Parallax SetLayers(List<BaseParallax.LayerData> layers) {
            _layers = layers;
            return this;
        }
        
        public Parallax InitLayers() {
            _func.InitLayers(_layers);
            return this;
        }

        public Parallax UpdateLayers() {
            _func.UpdateLayers(_camera.position, 
                               _sceneCenter,
                               _layers);
            return this;
        }

    #endregion
    }
}
