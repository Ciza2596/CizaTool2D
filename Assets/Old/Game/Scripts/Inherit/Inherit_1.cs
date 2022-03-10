using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inherit
{
    public class Inherit_1 : Inherit_Base
    {
        private void Start()
        {
            Hello();
        }

        public override void Hello()
        {
            base.Hello();
            Debug.Log("1");
        }
    } 
}

