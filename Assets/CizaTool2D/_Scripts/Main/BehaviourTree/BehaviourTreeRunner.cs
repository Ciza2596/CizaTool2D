using System.Collections;
using UnityEngine;
using CizaTool2D.BehaviourTree.Action;
using CizaTool2D.BehaviourTree.Base;

namespace CizaTool2D.BehaviourTree
{
    public interface IPlayerValues
    {
        float     GetHealth();
        Transform GetTransform();
        bool      GetIsAttackingState();
    }

    public interface IEnemyValues
    {
        float     GetHealth();
        float     GetArmor();
        Transform GetTransform();
    }

    public class BehaviourTreeRunner : MonoBehaviour
    {
        [SerializeField] private string            _targetName = "Player";
        [SerializeField] private GameObject        _self;
        [SerializeField] private BehaviourTreeView _treeView;
        [SerializeField] private GameObject        _convertors;

        private Data      _data;
        private Coroutine _parser;

        private void Start() {
            TreeViewInit();

            _parser = StartCoroutine(UpdateTreeView());
        }

        private void TreeViewInit() {
            _data = new Data(_convertors.GetComponent<IAnimator>(),
                             GameObject.Find(_targetName).GetComponent<IPlayerValues>(),
                             _self.GetComponent<IEnemyValues>());

            foreach(BaseNode node in _treeView.nodes){
                node.SetData(_data);

                var startNode = node as StartNode;
                if(startNode != null)
                    _treeView.CurrentNode = startNode;
            }
        }

        IEnumerator UpdateTreeView() {
            var currentNode = _treeView.CurrentNode;

            var actionNode = currentNode as ActionNode;
            var optionNode = currentNode as OptionNode;

            yield return null;

            string exit = "Exit";
            
            if(actionNode != null)
                actionNode.Execute();
            else
                exit = optionNode.GetBool() ? "TrueExit" : "FalseExit";


            NextNode(exit);
        }

        public void NextNode(string fieldName) {
            if(_parser != null){
                StopCoroutine(_parser);
                _parser = null;
            }

            foreach(var nodePort in _treeView.CurrentNode.Ports){
                if(nodePort.fieldName == fieldName){
                    _treeView.CurrentNode = nodePort.Connection.node as BaseNode;
                }
            }

            _parser = StartCoroutine(UpdateTreeView());
        }

        public class Data
        {
        #region Constructor

            public Data(IAnimator animator, IPlayerValues playerValues, IEnemyValues enemyValues) {
                Animator         = animator;
                PlayerValues     = playerValues;
                EnemyValues      = enemyValues;
                IsAttackingState = false;
            }

        #endregion

            public readonly IAnimator     Animator;
            public readonly IPlayerValues PlayerValues;
            public readonly IEnemyValues  EnemyValues;
            public          bool          IsAttackingState;
        }
    }
}
