using CizaTool2D.BehaviourTree.Base;
using UnityEngine;

namespace CizaTool2D.BehaviourTree.Action
{
    public class SetIsAttackingState : ActionNode
    {
        [Input]  public int Entry;
        [Output] public int Exit;

        [SerializeField] private bool _isAttackingState;
        
        public override void Execute() => _data.IsAttackingState = _isAttackingState;
    }
}
