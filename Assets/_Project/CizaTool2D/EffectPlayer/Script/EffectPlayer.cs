using System.Collections.Generic;
using CizaTool2D.EffectPlayer.Exposed;
using CizaTool2D.EffectPlayer.Package;
using CizaTool2D.Utility.Editor;
using CizaTool2D.Utility.RandomNumber;
using CizaTool2D.Utility.Component;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CizaTool2D.EffectPlayer
{
    public class EffectPlayer : IEffectPlayer
    {
        private IRandomNumber randomNumber = new NormalRandomNumber();

    #region === Operation Group ===

        [PropertyOrder(15)]
        [BoxGroup("Operation")]
        [ReadOnly]
        [SerializeField]
        private ISubEffectPlayerOperation subEffectPlayerOperation;


        private ISubEffectPlayer currentSubEffectPlayer;

        [PropertyOrder(20)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        private ISubEffectPlayer _CurrentSubEffectPlayer {
            get => currentSubEffectPlayer;
            set {
                currentSubEffectPlayer = value;

                CheckSubAudioPlayerOperation();

                if(subEffectPlayerOperation != null){
                    subEffectPlayerOperation.SetSubEffectPlayer(currentSubEffectPlayer.GetSubEffectPlayer());
                    _Loop = loop;
                }
            }
        }


        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [GUIColor("GetPlayButtonColor")]
        [Button]
        public override void Play() {
            _CurrentSubEffectPlayer = subEffectPlayers.GetRandomComponent(randomNumber);

            if(_CurrentSubEffectPlayer != null) 
                subEffectPlayerOperation.Play();
        }

        [PropertyOrder(35)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public override void Stop() {
            if(subEffectPlayerOperation != null && subEffectPlayerOperation .GetIsPlaying()) 
                subEffectPlayerOperation.Stop();
        }

    #endregion

    #region === Settings Group ===

        [HideInInspector]
        [SerializeField]
        private bool loop;

        [PropertyOrder(45)]
        [BoxGroup("Settings")]
        [ShowInInspector]
        private bool _Loop {
            get => loop;
            set {
                loop = value;
                subEffectPlayerOperation.SetLoop(loop);
            }
        }

        [PropertyOrder(50)]
        [BoxGroup("Settings")]
        [SerializeField]
        private List<ISubEffectPlayer> subEffectPlayers = new List<ISubEffectPlayer>();

    #endregion

    #region === Set, Get ===

        public override void Init(IEffectPlayer ieffectPlayer) {
            
            if(ieffectPlayer is EffectPlayer audioPlayer){
                loop  = audioPlayer.loop;

                subEffectPlayers = audioPlayer.subEffectPlayers;
            }
        }

        public override bool GetIsPlaying() {
            return subEffectPlayerOperation.GetIsPlaying();
        }

    #endregion


    #region === Private Methods ===

    #region == CheckSubEffectPlayerOperation ==

        private void CheckSubAudioPlayerOperation() {
            Stop();
            if(_CurrentSubEffectPlayer == null)
                return;
            
            if(subEffectPlayerOperation == null)
                subEffectPlayerOperation = GetComponentInChildren<ISubEffectPlayerOperation>();
            
            var currentType = _CurrentSubEffectPlayer.GetType();
            if(currentType != subEffectPlayerOperation.GetType())
                subEffectPlayerOperation = (ISubEffectPlayerOperation)GetComponentInChildren(currentType);
        }

    #endregion

    #region == DrawButton ==

        private Color GetPlayButtonColor() {
            if(subEffectPlayerOperation != null){
                if(subEffectPlayerOperation.GetIsPlaying())
                    return ButtonColor.GetPlayColor();
            }

            return ButtonColor.GetNormalColor();
        }

        private Color GetNormalColor() {
            return ButtonColor.GetNormalColor();
        }

    #endregion

    #endregion
    }
}
