using CizaTool2D.BehaviourTree.Base;
using UnityEngine;


namespace CizaTool2D.BehaviourTree.Action
{
    public class PlayAnim : ActionNode
    {

        [Input]  public int Entry;
        [Output] public int Exit;

        [SerializeField]
        private string _animStateName;
                     /*
        public override void Execute() => _data.Animator.Play(0,
                                                              _animStateName,
                                                              false,
                                                              1);  */
    }
    
}

