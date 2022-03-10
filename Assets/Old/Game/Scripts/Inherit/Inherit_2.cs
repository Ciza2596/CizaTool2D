using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inherit
{
    public class Inherit_2 : Inherit_1
    {
        public override void Hello()
        {
            base.Hello();
            Debug.Log("2");
        }
    }  
}

