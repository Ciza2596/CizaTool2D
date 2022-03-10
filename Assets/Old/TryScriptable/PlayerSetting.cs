using System;
using UnityEngine;

namespace TryScriptableObject
{    
    [CreateAssetMenu(fileName = "PlayerSetting", menuName = "ScriptableObjects/PlayerSetting")]
    public class PlayerSetting : ScriptableObject
    {
        #region = Private Variables =

        [SerializeField] private BaseValue _baseValue;
        [SerializeField] private AnimName _animName;

        #endregion

        #region = Public Methods =

        public float GetHp()
        {
            return _baseValue.Hp;
        }
        
        public float GetMoveSpeed()
        {
            return _baseValue.MoveSpeed;
        }

        public string GetIdleAnimName()
        {
            return _animName.Idle;
        }

        #endregion


        #region = Setting =
        
        [Serializable]
        public class BaseValue
        {
            public float Hp;
            public float MoveSpeed;
        }

        #endregion

        #region = Anim =
        [Serializable]
        class AnimName
        {
            public string Idle;
            public string Attack;
        }
        

        #endregion

    } 
}