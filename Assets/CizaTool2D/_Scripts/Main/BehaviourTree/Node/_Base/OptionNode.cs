namespace CizaTool2D.BehaviourTree.Base
{
    public class OptionNode : BaseNode
    {
        [Input]  public int Entry;
        [Output] public int TrueExit;
        [Output] public int FalseExit;

        public virtual bool GetBool() {
            return false;
        }
    }
}
