using System.Collections.Generic;
using CizaTool2D.EffectPlayer.Exposed;
using CizaTool2D.EffectPlayer.Package;
using CizaTool2D.Utility.Editor;
using CizaTool2D.Utility.RandomNumber;
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
            _CurrentSubEffectPlayer = GetRandomComponent(in subEffectPlayers);

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

    #region == CheckSubEffectPlayerOperation(如果新增子類，只需改動這裡) ==

        private void CheckSubAudioPlayerOperation() {
            Stop();
            if(_CurrentSubEffectPlayer is AnimEffectPlayer && !(subEffectPlayerOperation is AnimEffectPlayer)){
                subEffectPlayerOperation = GetComponentInChildren<AnimEffectPlayer>();
            }else if(_CurrentSubEffectPlayer is ParticleEffectPlayer && !(subEffectPlayerOperation is ParticleEffectPlayer)){
                subEffectPlayerOperation = GetComponentInChildren<ParticleEffectPlayer>();
            }
        }

    #endregion

    #region == Random ==

        private T GetRandomComponent<T>(in List<T> audioClipPlayers) where T : Component {
            var count = audioClipPlayers.Count;
            if(count == 1){
                return audioClipPlayers[0];
            }
            else if(count == 2){
                return audioClipPlayers[randomNumber.GetRandomNumberForTwo()];
            }
            else if(count >= 3){
                return audioClipPlayers[randomNumber.GetRandomNumberForMoreThree(count)];
            }
            else{
                return null;
            }
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
