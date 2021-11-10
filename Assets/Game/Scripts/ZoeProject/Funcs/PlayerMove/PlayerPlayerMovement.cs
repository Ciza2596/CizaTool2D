using CizaTool2D;
using UnityEngine;

namespace ZoeProject
{
    public class PlayerPlayerMovement : MonoBehaviour, IPlayerMovement
    {
        [SerializeField] private GameObject _facades;

        private void Start()
        {
            _facades.GetComponent<IRigidbody2D>();
        }
    } 
}
