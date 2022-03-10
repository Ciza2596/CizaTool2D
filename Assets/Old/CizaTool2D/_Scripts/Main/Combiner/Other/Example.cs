using UnityEngine;

namespace CizaTool2D.Combiner
{
    public class Example : MonoBehaviour
    {
        [SerializeField]
        private EnemyData enemyData;

        [SerializeField]
        [InsideInject("Converter")]
        private GameObject _converter;
    }
}
