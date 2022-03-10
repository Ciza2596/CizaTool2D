using CizaTool2D.BehaviourTree.Base;
using UnityEngine;
using XNode;

namespace CizaTool2D.BehaviourTree
{
    [CreateAssetMenu(fileName = "New BehaviourTreeView", menuName = "CizaTool/BehaviourTreeView")]
    public class BehaviourTreeView : NodeGraph
    {
        public BaseNode CurrentNode;
        

    }
}
