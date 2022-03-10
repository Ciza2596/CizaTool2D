using System.Collections;
using DialogSystem.Base;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class NodeParser : MonoBehaviour
    {
        public  DialogueGraph Graph;
        private Coroutine     _parser;

        public Text  Speaker;
        public Text  Dialogue;
        public Image SpeakerImage;
        

        private void Start() {
            foreach(BaseNode node  in Graph.nodes){
                if(node.GetString() == "Start"){
                    //Make this node the starting point
                    Graph.current = node;
                    break;
                }
            }

            _parser = StartCoroutine(ParseNode());

        }

        IEnumerator ParseNode() {
            BaseNode node      = Graph.current;
            string   data      = node.GetString();
            string[] dataParts = data.Split('/');
            if(dataParts[0] == "DialogueNode"){
                Speaker.text        = dataParts[1];
                Dialogue.text       = dataParts[2];
                SpeakerImage.sprite = node.GetSprite();
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                NextNode("exit");
            }
        }

        public void NextNode(string fieldName) {
            if(_parser != null){
                StopCoroutine(_parser);
                _parser = null;
            }

            foreach(var nodePort in Graph.current.Ports){

                if(nodePort.fieldName == fieldName){
                    Graph.current = nodePort.Connection.node as BaseNode;
                }
            }

            _parser = StartCoroutine(ParseNode());
        }
    }
}
