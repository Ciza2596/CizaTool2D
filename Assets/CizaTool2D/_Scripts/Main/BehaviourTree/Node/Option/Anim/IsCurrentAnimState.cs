using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree.Option.Anim
{
    public class IsCurrentAnimState :  OptionNode
    {
        public string _animStateName;

        public override bool GetBool() => _data.Animator.GetIsCurrentState_Name(0,_animStateName);
    }
}

