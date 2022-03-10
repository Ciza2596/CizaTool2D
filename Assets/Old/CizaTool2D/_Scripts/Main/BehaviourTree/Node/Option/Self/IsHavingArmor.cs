using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree.Option.Self
{
    public class IsHavingArmor : OptionNode
    {
        public          int  Armor = 0;
        public override bool GetBool() => _data.EnemyValues.GetArmor() <= Armor;
    }
}

