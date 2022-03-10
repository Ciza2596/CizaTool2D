using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree.Option.Anim
{
    public class IsAnimStateNotNull : OptionNode
    {   

        public string _animStateName;

        public override bool GetBool() => true; //_data.Animator.GetIsClipNotNull(_animStateName);
    } 
}

