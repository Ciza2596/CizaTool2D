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

        [SerializeField] private GameObject                     _body;
        [SerializeField] private List<AddComponentList>         _addComponentLists;
        private                  Dictionary<string, Transform> _bodyList;

        private bool GetIsNull(object obj, string log) {
            return Utility.Utility.GetIsObjectNull(obj,
                                                   () => Debug.Log(log));
        }


        [Button(ButtonSizes.Large)]
        private void Create() {
            if(GetIsNull(_body, "Body is null"))
                return;
            
            var gameObject = PrefabUtility.InstantiatePrefab(_body) as GameObject;
            PrefabUtility.UnpackPrefabInstance(gameObject, 
                                               PrefabUnpackMode.Completely,
                                               InteractionMode.AutomatedAction);

            _bodyList = new Dictionary<string, Transform>();
            BuildBodyList(gameObject.transform);
            
            Combine();

            gameObject.name = _name;
            PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, "Assets/"+_savePath+"/" + gameObject.name + ".prefab", InteractionMode.AutomatedAction);
        }

        //把目前放進的body做個清單
        private void BuildBodyList(Transform objTransform) {
              _bodyList.Add( objTransform.name, objTransform);
              var length = objTransform.childCount;
              
              if(length > 0){
                  for(int i = 0; i < length; i++){
                      BuildBodyList(objTransform.GetChild(i));
                  }
              }
        }

        private void Combine() {

            if(GetIsNull(_addComponentLists, "AddComponentLists is null"))
                return;

            foreach(var addComponentList in _addComponentLists){
                var objName = addComponentList.ObjName;
                if(_bodyList.ContainsKey(objName)){
                    var objTransform = _bodyList[objName];
                    var components = addComponentList.Components;
                    foreach(var component in components){
                        UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(objTransform.gameObject, "Assets/CizaTool2D/_Scripts/Main/Combiner/Combiner.cs (70,25)", component);
                    }
                }
                else{
                    Debug.Log($"{objName} is not in body");
                }
            }
        }


        [Serializable]
        class AddComponentList
        {
            public string              ObjName;
            public List<string> Components;
        }
    }
}

