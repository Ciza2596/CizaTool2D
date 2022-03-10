using UnityEngine;


namespace CizaTool2D.Singleton
{
    public class SceneSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T sInstance = null;

        public static T Instance {
            get {
                //Debug.Log("SceneSingleton: Instance.get. sInstance=" + sInstance);
                if (sInstance != null) {
                    return sInstance;
                }


                sInstance = FindObjectOfType<T>();
                //sInstance = GetSceneInstance();
                if (sInstance == null) {
                    Debug.Log ("SceneSingleton: <" + typeof(T) + "> instance has been not found.");
                }

                return sInstance;
            }
        }

        protected static bool IsInstance(GameObject checkObject) {
            return (checkObject.gameObject.scene.name != null);

            //} //Debug.Log("It's a prefab!");)
            //Debug.Log("SceneSingleton.IsInstace type=" + PrefabUtility.GetPrefabObject(checkObject));

            //return PrefabUtility.GetPrefabType(checkObject) != PrefabType.Prefab;
        }

        protected static T GetSceneInstance() {
            Debug.Log ("SceneSingleton: GetSceneInstance");
            T[] result = FindObjectsOfType<T>();
            foreach (T resultItem in result) {
                Debug.Log ("SceneSingleton: ResultItem: " + resultItem);
            }

            return null;
        }

        protected virtual void DidAwake() {
        }

        protected void Awake() {
            Debug.Log ("SceneSingleton: Awake Logic! sInstance=" + sInstance);
            //if (sInstance == null) {
            if (IsInstance (gameObject)) {
                sInstance = this as T;
            }

            DidAwake();
            // if (instance == null) {
            // 	instance = this as T;
            // } else if (instance != this) {
            // 	DestroySelf();
            // }
        }

        protected void OnValidate() {
            if (sInstance == null) {
                sInstance = this as T;
                // } else if (instance != this) {
                // 	Debug.LogError("Singleton<"+this.GetType() + "> already has an instance on scene. Component will be destroyed.");
                // 	#if UNITY_EDITOR
                // 	UnityEditor.EditorApplication.delayCall -= DestroySelf;
                // 	UnityEditor.EditorApplication.delayCall += DestroySelf;    
                // 	#endif
            }
        }


        private void DestroySelf() {
            // if(Application.isPlaying) {
            // 	Destroy(this);
            // } else {
            // 	DestroyImmediate(this);
            // }
        }
    }
}