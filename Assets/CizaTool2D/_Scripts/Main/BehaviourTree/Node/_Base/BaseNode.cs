using XNode;

namespace CizaTool2D.BehaviourTree.Base
{
    public  class BaseNode : Node
    {
        protected BehaviourTreeRunner.Data _data; 
        
        
        public void SetData(BehaviourTreeRunner.Data data) {
            _data = data;
        }
    }
}
