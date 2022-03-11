using System.Collections.Generic;
using UnityEngine;


namespace CizaTool2D.Utility.Component
{
    public static class SearchComponent
    {
        public static T GetComponentInChildren<T>(this GameObject gameObject) where T : UnityEngine.Component {
            var t = gameObject.GetComponent<T>();

            if(t != null)
                return t;

            var transform  = gameObject.transform;
            var childCount = transform.childCount;

            if(childCount <= 0)
                return null;

            for(int i = 0; i < childCount; i++){
                t = GetComponentInChildren<T>(transform.GetChild(i).gameObject);
                if(t != null)
                    return t;
            }

            return null;
        }

        public static void GetComponentsInChildren<T>(this GameObject gameObject, ref List<T> returnTs) where T : UnityEngine.Component {
            T t = gameObject.GetComponent<T>();
            if(t != null)
                returnTs.Add(t);

            var transform  = gameObject.transform;
            var childCount = transform.childCount;
            if(childCount <= 0)
                return;

            for(int i = 0; i < childCount; i++){
                GetComponentsInChildren(transform.GetChild(i).gameObject, ref returnTs);
            }
        }
    }
}
