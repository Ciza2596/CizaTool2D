using System.Collections.Generic;
using UnityEngine;

namespace CizaTool2D.Combiner
{
    [CreateAssetMenu(fileName = "New PrefabArchitecture", menuName = "CizaTool/Combiner/PrefabArchitecture")]
    public class PrefabArchitecture : ScriptableObject
    {
        public GameObject             _body;
        public List<AddComponentNames> _addComponentNamesList;
    }
}