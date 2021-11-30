using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace CizaTool2D.Combiner
{
    
    [CreateAssetMenu(fileName = "New Combiner", menuName = "CizaTool/Combiner")]
    public class Combiner : ScriptableObject
    {
        [SerializeField] 
        private string _name;
        
        [SerializeField]
        private string _savePath;

        [SerializeField] private GameObject       _body;
        [SerializeField] private AddComponentList _addComponentList;


        [Button(ButtonSizes.Large)]
        private void Create() {
            var gameObject = PrefabUtility.InstantiatePrefab(_body) as GameObject;
            gameObject.name = _name;

            Combine(gameObject);

            PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, "Assets/"+_savePath+"/" + gameObject.name + ".prefab", InteractionMode.AutomatedAction);
        }

        private void Combine(GameObject gameObject) {
            
        }


        [Serializable]
        class AddComponentList
        {
            public string              GameObjectName;
            public List<MonoBehaviour> Components;
        }
    }
}

