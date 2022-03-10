using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExUpdateAction
{
    public class ObjAction_2 : MonoBehaviour
    {
        private void OnEnable()
        {
            ExUpdateAction_2.ExUpdate += Greet;
        }

        private void OnDisable()
        {
            ExUpdateAction_2.ExUpdate -= Greet;
        }

        void Greet()
        {
            Debug.Log("Hello_2");
        }
    }
}

