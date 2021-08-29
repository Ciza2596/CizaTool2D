using System;
using UnityEngine;
using CizaTools2D;

namespace Try
{
    public class PlaySpineAnim : MonoBehaviour
    {
        [SerializeField] private GameObject _facades;

        [SerializeField] private bool _hold;

        [SerializeField] private Settings _settings;

        private IAnimator _animator;

        // Start is called before the first frame update
        void Start()
        {
            _animator = _facades.GetComponent<IAnimator>();

            _animator.Play(0,_settings.Main.name, true, 1f );
        }

        //0: 基本動作，1: 進戰武器，2: 遠程武器，3: 表情
        // Update is called once per frame
        void Update()
        {
            /*
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                        
                _animator.Play(0, "Move_Walk", true, 0.1f); 
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                
                
                _animator.Play(0, "Move_Run", true, 0.1f); 
            }
            else if(Input.GetKeyDown(KeyCode.Z))
            {
                
                
                _animator.Play(0, "Move_Rush", true, 0.1f);
            } */
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                float normlizeTime = _animator.GetNormalizeTime(0);
                string name = _animator.GetName(0);
                
                if (name == "Move_Run" || name == "Move_Rush")
                    normlizeTime /=2;
                        
                _animator.PlayAtNormalizeTime(0, normlizeTime,"Move_Walk", true, 1); 
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                float normlizeTime = _animator.GetNormalizeTime(0);
                string name = _animator.GetName(0);
                
                if (name == "Move_Walk")
                    normlizeTime *= 2;
                
                _animator.PlayAtNormalizeTime(0, normlizeTime,"Move_Run", true, 1); 
            }
            else if(Input.GetKeyDown(KeyCode.Z))
            {
                float normlizeTime = _animator.GetNormalizeTime(0);
                string name = _animator.GetName(0);
                
                if (name == "Move_Walk")
                    normlizeTime *= 2;
                
                _animator.PlayAtNormalizeTime(0, normlizeTime,"Move_Rush", true, 1);
            }


            /*
            if (Input.GetKeyDown(KeyCode.Q))
                _animator.Play(1,"Sword_Background", true, 0.5f); 
            
            Debug.Log(_animator.GetNormalizeTime(0));
            
            if (Input.GetKeyDown(KeyCode.Mouse1) && !_hold)
                _hold = true;

            if (Input.GetKeyUp(KeyCode.Mouse1) && _hold)
                _hold = false;
            
            if (Input.GetKeyUp(KeyCode.Mouse0) && _hold)
                _animator.Play(2,"Gatling_Shooting", true, 0.1f);

            if (_hold)
            {
                if (_animator.GetName(0) == "Gun_Walk") return;
                
                float normlizeTime = _animator.GetNormalizeTime(0);
                
                _animator.PlayAtNormalizeTime(0, normlizeTime,"Gun_Walk", true, 1f);
                _animator.Play(2, "Gatling_Idle", true, 1f);
                //_animator.SetAnim("Default-Face-Wink",true,3);
            }
            else
            {
                if (_animator.GetName(0) != _settings.Main.name)
                {
                    float currentTime = _animator.GetTime(0);
                    _animator.PlayAtTime(0,currentTime, _settings.Main.name, true, 1f);  
                }

                if (_animator.GetName(2) != "Gatling_Background")
                    _animator.Play(2,"Gatling_Background", true, 1);  
            }
            /*
             if(Input.GetKeyDown(KeyCode.Mouse0))
                 _animator.SetAnim("Sword_Attack_A1", false, 1);
                 //_animator.PlayAnim("Sword_Attack_A1", false, _settings.Main.timeScale);
 
 
 
             if (Input.GetKeyDown(KeyCode.Q))
                 _animator.SetAnim("Sword_Background", true, 1);
             if (Input.GetKeyDown(KeyCode.A))
                 _animator.ClearTrack(1);
 
             if (Input.GetKeyDown(KeyCode.E))
                 _animator.SetAnim("Gatling_Background", true, 2);
             if (Input.GetKeyDown(KeyCode.D))
                 _animator.SetAnim("Flamethrower_Background", true, 2);      */
        }

        [Serializable]
        public class Settings
        {
            public Main Main;
            public Sub Sub;
            public Equip Equip;
        }

        [Serializable]
        public class Main
        {
            public string name;
            public float timeScale = 1;
        }

        [Serializable]
        public class Sub
        {
            public string name;
        }

        [Serializable]
        public class Equip
        {
            public string name;
        }
    }
}