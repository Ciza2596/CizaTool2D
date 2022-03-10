using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StaticDependenceMethods
{
    public class EnemySetting
    {
        private string _name;

        public EnemySetting(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}