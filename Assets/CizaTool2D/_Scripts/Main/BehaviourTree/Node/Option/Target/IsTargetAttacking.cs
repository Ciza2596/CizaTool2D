using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree.Option.Target
{
    public class IsTargetAttacking : OptionNode
    {
        public override bool GetBool() => _data.PlayerValues.GetIsAttackingState();
        
    }
}

