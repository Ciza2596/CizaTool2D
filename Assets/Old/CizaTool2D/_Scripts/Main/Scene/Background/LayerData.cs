using System;
using UnityEngine;

namespace CizaTool2D.Scene.Background
{
    [Serializable]
    public class LayerData
    {
        public Transform Transform;
        public Vector2   MovingDistance;

        [HideInInspector] public Vector3 CenterPos;
    }
}
