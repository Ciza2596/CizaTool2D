using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree.Option.Self
{
    public class IsHavingHealth : OptionNode
    {
        public          int  Health = 0;
        public override bool GetBool() => _data.EnemyValues.GetHealth() <= Health;
    }

}

