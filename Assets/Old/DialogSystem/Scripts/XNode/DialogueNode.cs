using DialogSystem.Base;
using UnityEngine;


namespace DialogSystem
{
    public class DialogueNode : BaseNode
    {
        [Input]  public int Entry;
        [Output] public int Exit;

        public string SpeakerName;
        public string DialogueLine;
        public Sprite Sprite;

        public override string GetString() {
            return "DialogueNode/" + SpeakerName + "/" + DialogueLine;
        }

        public override Sprite GetSprite() {
            return Sprite;
        }
    }
}

