using System;
using System.Collections.Generic;
using UnityEngine;


namespace CizaTool2D.Scene.Background
{
    public class BaseParallax
    {
    #region = Public Methods =

        public void InitLayers(List<LayerData> layers) {
            if(layers != null)
                foreach(var layer in layers)
                    layer.CenterPos = layer.Transform.position;
        }

        public void UpdateLayers(Vector2         cameraPos,
                                 Vector2         sceneCenter,
                                 List<LayerData> layers) {
            if(layers == null)
                return;

            foreach(var layer in layers)
                UpdateLayer(cameraPos,
                            sceneCenter,
                            layer);
        }

        public void UpdateLayer(Vector2   cameraPos,
                                Vector2   sceneCenter,
                                LayerData layer) {
            if(layer == null)
                return;
            
            var transform      = layer.Transform;
            var movingDistance = layer.MovingDistance;
            var centerPos      = layer.CenterPos;

            var distance = new Vector2((cameraPos.x - sceneCenter.x) * movingDistance.x,
                                       (cameraPos.y - sceneCenter.y) * movingDistance.y);

            if(transform != null)
                transform.position = new Vector3(centerPos.x + distance.x,
                                                 centerPos.y + distance.y,
                                                 centerPos.z);
        }

    #endregion

    #region = Setting =

        [Serializable]
        public class LayerData
        {
            public Transform Transform;
            public Vector2   MovingDistance;

            [HideInInspector] public Vector3 CenterPos;
        }

    #endregion
    }
}
