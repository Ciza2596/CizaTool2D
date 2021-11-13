using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree.Option.Target
{
    public class IsTargetHealth : OptionNode
    {
        public          int  Health = 0;
        public override bool GetBool() => _data.PlayerValues.GetHealth() < Health;
    }
}
