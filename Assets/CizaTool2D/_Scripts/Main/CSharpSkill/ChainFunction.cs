using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CizaTool2D.CSharpSkill
{
    public class ChainFunction : MonoBehaviour
    {
        void Start() {

        #region normalPlayer
            
            var normalPlayer = new NormalPlayer();
            normalPlayer.SetHP(10);
            normalPlayer.SetMP(10);
            normalPlayer.LogInfo();

        #endregion
            
        #region chainFuncPlayer
            
            var chainFuncPlayer = new ChainFuncPlayer();
            chainFuncPlayer.SetHP(10)
                           .SetMP(10)
                           .LogInfo();

        #endregion

        }

    #region - Private Class -

        class BasePlayer
        {
            public float HP { get; protected set; }
            public float MP { get; protected set; }

            protected void LogInfo(string typeName) {
                Debug.Log($"{typeName} \n Hp: {HP}, MP: {MP}");
            }
        }


        class NormalPlayer: BasePlayer
        {
            public void SetHP(float hp) {
                HP = hp;
            }
            
            public void SetMP(float mp) {
                MP = mp;
            }

            public void LogInfo() {
                LogInfo(GetType().ToString());
            }
        }

        
        class ChainFuncPlayer: BasePlayer
        {
            public ChainFuncPlayer SetHP(float hp) {
                HP = hp;
                return this;
            }
            
            public ChainFuncPlayer SetMP(float mp) {
                MP = mp;
                return this;
            }

            public ChainFuncPlayer LogInfo() {
                LogInfo(GetType().ToString());
                return this;
            }
        }
        
        #endregion
        
    }
}
