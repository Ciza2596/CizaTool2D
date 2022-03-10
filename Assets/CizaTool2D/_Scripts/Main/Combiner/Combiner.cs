using System.Collections.Generic;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;

namespace CizaTool2D.Combiner
{
    [CreateAssetMenu(fileName = "New Combiner", menuName = "CizaTool/Combiner/Combiner")]
    public class Combiner : ScriptableObject
    {
        [SerializeField] private string                 _name;
        [SerializeField] private string                 _savePath;
        [SerializeField] private List<Object> _dataList;
        [Space]
        [SerializeField] private PrefabArchitecture _prefabArchitecture;


        private Dictionary<string, Transform> _bodyDict;
        private Dictionary<string, Component> _componentDict;

        private bool GetIsNull(object obj, string log) {
            return Utility.Utility.GetIsObjectNull(obj,
                                                   () => Debug.Log(log));
        }


        [Button(ButtonSizes.Large)]
        private void Create() {
            if(GetIsNull(_prefabArchitecture._body, "Body is null"))
                return;

            var gameObject = PrefabUtility.InstantiatePrefab(_prefabArchitecture._body) as GameObject;
            PrefabUtility.UnpackPrefabInstance(gameObject,
                                               PrefabUnpackMode.Completely,
                                               InteractionMode.AutomatedAction);

            _bodyDict = new Dictionary<string, Transform>();
            BuildBodyDict(gameObject.transform);

            AddComponentsAndBuildDict();
            CombineEachComponent();
            CombineOutsideData();

            gameObject.name = _name;
            PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject,
                                                      "Assets/" + _savePath + "/" + gameObject.name + ".prefab",
                                                      InteractionMode.AutomatedAction);
        }

        //把目前放進的body做個清單
        private void BuildBodyDict(Transform objTransform) {
            _bodyDict.Add(objTransform.name.ToLower(), objTransform);
            var length = objTransform.childCount;

            if(length > 0){
                for(int i = 0; i < length; i++){
                    BuildBodyDict(objTransform.GetChild(i));
                }
            }
        }

        //將Component組裝到body上
        private void AddComponentsAndBuildDict() {
            if(GetIsNull(_prefabArchitecture._addComponentNamesList, "AddComponentLists is null"))
                return;

            _componentDict = new Dictionary<string, Component>();

            foreach(var addComponentNameList in _prefabArchitecture._addComponentNamesList){
                var objName = addComponentNameList.ObjName.ToLower();
                if(_bodyDict.ContainsKey(objName)){
                    var objTransform   = _bodyDict[objName];
                    var componentNames = addComponentNameList.ComponentNames;
                    foreach(var componentName in componentNames){
                        
                        if(string.IsNullOrEmpty(componentName))
                            continue;
                        
                        var compoent = 
                            APIUpdaterRuntimeServices.AddComponent(objTransform.gameObject, 
                                                                   "CizaTool2D/Combiner", 
                                                                   componentName);

                        if(!_componentDict.ContainsKey(componentName))
                            _componentDict.Add(componentName, compoent);
                        /*
                         Interface 目前無法存在prefab
                        var interfaces = compoent.GetType().GetInterfaces();
                        foreach(var _interface in interfaces){

                            var interfaceName = _interface.Name;
                            if(!_componentDict.ContainsKey(interfaceName))
                                _componentDict.Add(interfaceName, compoent);
                        }*/
                    }
                }
                else{
                    Debug.Log($"{objName} is not in body");
                }
            }
        }

        //將各個Component內所需其他Component的field裝上。
        private void CombineEachComponent() {
            foreach(var componentData in _componentDict){
                var component = componentData.Value;
                var fields    = component.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                
                foreach(var field in fields){

                    var isComponent = field.FieldType.IsSubclassOf(typeof(Component));
                    var isGameObject = field.FieldType.IsEquivalentTo(typeof(GameObject));

                    if(isComponent){
                        //Is Component
                        var fieldTypeName = field.FieldType.Name;

                        if(_componentDict.ContainsKey(fieldTypeName))
                            field.SetValue(component, _componentDict[fieldTypeName]);
                    }
                    else if (isGameObject)
                    {
                        //Is GameObject
                        var injects = (InsideInjectAttribute[]) field.GetCustomAttributes(typeof(InsideInjectAttribute), true);
                        if (injects.Length <= 0)
                            continue;
                        
                        var inject         = injects[0];
                        var gameObjectName = inject.GameObjectName.ToLower();
                        if(_bodyDict.ContainsKey(gameObjectName))
                            field.SetValue(component, _bodyDict[gameObjectName].gameObject);
                        
                    }
                }  
            }
        }
        
        //將外部資料注入進來
        private void CombineOutsideData() {
            if(_dataList == null || _dataList.Count <= 0)
                return;

            foreach(var data in _dataList){
                var dataTypeName = data.GetType().Name;

                if(dataTypeName == "AnimatorOverrideController"){
                    dataTypeName = "RuntimeAnimatorController";
                }

                foreach(var componentData in _componentDict){
                    var component = componentData.Value;


                #region Field

                    var fields    = component.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    
                    foreach(var field in fields){
                        var fieldTypeName = field.FieldType.Name;
                        if(dataTypeName == fieldTypeName)
                            field.SetValue(component, data);
                    }

                #endregion
                    
                #region Property

                    var properties    = component.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    
                    foreach(var property in properties){
                        var propertyTypeName = property.PropertyType.Name;
                        if(dataTypeName == propertyTypeName)
                            property.SetValue(component, data);
                    }

                #endregion 
                }
            }

        }
    }
}
