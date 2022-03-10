using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZoeProject{

    public class TryArray : MonoBehaviour
    {
        private int[] numbers = new int[3];
        void Start()
        { 
            Debug.Log(numbers.Length);
        }

    }
}
