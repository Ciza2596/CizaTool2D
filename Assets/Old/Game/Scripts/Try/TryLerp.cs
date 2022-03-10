using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryLerp : MonoBehaviour
{
    [SerializeField] private float _normlizeNumber;
    [SerializeField] private float _maxNumber;
    [SerializeField] private float _miniNumber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            float currentNumber = Mathf.Lerp(_miniNumber, _maxNumber, _normlizeNumber);
            
            Debug.Log(currentNumber);
        }

    }
}
