

using DialogSystem.Base;

namespace DialogSystem
{
    public class StartNode : BaseNode
    {
        [Output] public int Exit;
        
        public override string GetString() {
            return "Start";
        }
    }
}
