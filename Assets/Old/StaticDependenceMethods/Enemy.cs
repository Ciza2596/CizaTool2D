using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StaticDependenceMethods
{
    public class Enemy
    {
        private static EnemySetting _enemySetting;

        public static void SetEnemySetting(EnemySetting enemySetting)
        {
            _enemySetting = enemySetting;
        }

        public void Say()
        {
            Debug.Log("My name is "+ _enemySetting.GetName());
        }

    }
    
}
