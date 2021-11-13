using CizaTool2D.BehaviourTree.Base;
using UnityEngine;

namespace CizaTool2D.BehaviourTree.Option.Target
{
    public class IsTargetDistance : OptionNode
    {
        public          Vector2 Distance;

        public override bool GetBool() {
            var playerPosition = _data.PlayerValues.GetTransform().position;
            var enemyPosition  = _data.EnemyValues.GetTransform().position;
            var distance       = new Vector2(Mathf.Abs(playerPosition.x - enemyPosition.x), Mathf.Abs(playerPosition.y - enemyPosition.y));
            
            return  distance.x < Distance.x && distance.y <Distance.y;
        }
    }
}
