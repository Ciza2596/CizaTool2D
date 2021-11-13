using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree.Option.Target
{
    public class IsTargetFaceToFace : OptionNode
    {
        public override bool GetBool() {
            
            var x = _data.PlayerValues.GetTransform().localScale.x * _data.EnemyValues.GetTransform().localScale.x;
            
            return x < 0;
        }
    }
}

