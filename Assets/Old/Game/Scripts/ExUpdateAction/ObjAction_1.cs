using UnityEngine;

namespace ExUpdateAction
{
    public class ObjAction_1 : MonoBehaviour
    {
        private void OnEnable()
        {
            ExUpdateAction_1.ExUpdate += Greet;
        }

        private void OnDisable()
        {
            ExUpdateAction_1.ExUpdate -= Greet;
        }

        void Greet()
        {
            Debug.Log("Hello_1");
        }
    } 
}
