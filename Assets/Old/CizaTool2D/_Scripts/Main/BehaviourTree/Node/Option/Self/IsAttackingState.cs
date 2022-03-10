using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree.Option.Self
{
    public class IsAttackingState : OptionNode
    {
        public override bool GetBool() => _data.IsAttackingState;
    }
}

