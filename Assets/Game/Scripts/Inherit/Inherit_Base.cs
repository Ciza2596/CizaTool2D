using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inherit{
    public class Inherit_Base : MonoBehaviour
    {
        public virtual void Hello()
        {
            Debug.Log("Base");
        }
    }
}
