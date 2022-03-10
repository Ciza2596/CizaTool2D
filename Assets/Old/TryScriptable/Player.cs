using System;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

namespace TryScriptableObject
{
    public class Player : MonoBehaviour
    {

        #region = Private Variables =

        [SerializeField] private PlayerSetting.BaseValue _base;

        private float _hp;
        [Space]
        [SerializeField] private PlayerSetting _setting;

        private Animator _animator;

        #endregion

        #region = UnityEvent =


        #region - Awake -

        private void Awake()
        {
            _hp = _setting.GetHp(); 
            Debug.Log(_setting.GetHp());
        }

        #endregion
        
        #region - Update -

        private void Update()
        {  /*
            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position +=  new Vector3(0,_setting.GetMoveSpeed(),0 );
            }           */
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W))                                                         //0.0001
            {                                                                                    //0.02
                transform.position +=  new Vector3(0,_setting.GetMoveSpeed(),0 ) *  Time.fixedDeltaTime;
            }/*
            else if ()
            {
                _animator.Play(_setting.GetIdleAnimName());
            }    */
        }

        #endregion
        

        #endregion
        
        #region = private Methods =

        

        #endregion

    }
}
