using CizaTool2D.ExampleTool.Func;
using UnityEngine;

namespace CizaTool2D.ExampleTool.Component
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed = 5;

        [SerializeField] private GameObject _converter;

        private Func.Movement _movement;

        private void Awake() => _movement = new Func.Movement()
                                    .SetTransform(_converter.GetComponent<ITransform>());

        private void Update() => _movement.SetSpeed(_speed)
                                          .Update();
    }
}
