
using UnityEngine;
using Spine.Unity;
using Spine;

namespace Try
{
    public class PlaySpineAnim : MonoBehaviour
    {
        public SkeletonAnimation _anim;
        
        [Space]
        
        [SpineAnimation]
        [SerializeField]
        private string _idle;              //2
        
        [SpineAnimation]
        [SerializeField]
        private string _rangedBackground;  //1
        
        [SpineAnimation]
        [SerializeField]
        private string _meleeBackground;   //0
        
        [Space]
        [SpineAnimation]
        [SerializeField]
        private string _meleeAttack;
        
        [SpineAnimation]
        [SerializeField]
        private string _meleeNonBackground;


        private void Start()
        {
            _anim.state.SetAnimation(2, _idle, true);
            
            _anim.state.SetAnimation(1, _rangedBackground, true);
            _anim.state.SetAnimation(0, _meleeBackground, true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _anim.state.SetAnimation(0, _meleeNonBackground, true);
                _anim.state.SetAnimation(2, _meleeAttack, true);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                _anim.state.SetAnimation(0, _meleeBackground, true);
                _anim.state.SetAnimation(2, _idle, true);
            }
            else if(Input.GetKeyDown(KeyCode.E))
                Debug.Log( GetName(0));

        }
        
        public string GetName(int index)
        {
            TrackEntry track =  _anim.state.GetCurrent(index);

            string name = 
                (track != null) ? 
                    track.Animation.Name : "Null";
            
            if(name == "Null") 
                Debug.Log($"anim index is {index} and null");
            
            return name;
        }
    }
}