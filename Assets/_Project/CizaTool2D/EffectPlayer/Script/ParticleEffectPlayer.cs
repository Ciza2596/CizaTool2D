using System.Collections.Generic;
using System.Linq;
using CizaTool2D.EffectPlayer.Package;
using CizaTool2D.Utility.Editor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CizaTool2D.EffectPlayer
{
    public class ParticleEffectPlayer: ISubEffectPlayerOperation
    {
         private ParticleManager particleManager;
        
    #region === Operation Group ===

        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [GUIColor("GetPlayButtonColor")]
        [Button]
        public override void Play() {
            if(!gameObject.activeSelf)
                return;
            
            particleManager.Stop();
            particleManager.Play();
        }
        
        [PropertyOrder(35)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public override void Stop() {
            particleManager.Stop();
        }
        
    #endregion
        
    #region === Settings Group ===

        [HideInInspector]
        [SerializeField]
        private float duration = 4;

        [PropertyOrder(39)]
        [BoxGroup("Settings")]
        [PropertyRange(1,5)]
        [ShowInInspector]
        private float _Duration {
            get => duration;
            set {
                duration = value;
                if(particleManager !=null) 
                    particleManager.SetDuration(duration);
            }
        }

    #endregion
        
    #region === Set, Get ===

        public List<Component> GetComponents() {
            CheckParticleManager();
            return particleManager.GetComponents();
        }

    #region ===  ISubEffectPlayer ===

        public override ISubEffectPlayer GetSubEffectPlayer() {
            return this;
        }

    #endregion

    #region === ISubEffectPlayerOperation ===

        public override void SetSubEffectPlayer(ISubEffectPlayer isubEffectPlayer) {
            if(isubEffectPlayer is ParticleEffectPlayer particleEffectPlayer){
                particleManager.SetComponents(particleEffectPlayer.GetComponents());
                _Duration = particleEffectPlayer.duration;
            }
        }

        public override void SetLoop(bool loop) {
            particleManager.SetLoop(loop);
        }
        
        public override bool GetIsPlaying() {
            return particleManager.IsPlaying;
        }

    #endregion

    #endregion

    #region === Awake ===

        private void Awake() {
            CheckParticleManager();
            particleManager.Stop();
        }

    #endregion
        
    #region === Private Methods ===
        
        private void CheckParticleManager() {
            if(particleManager != null)
                return;

            particleManager = new ParticleManager(gameObject.GetComponentsInChildren<ParticleSystem>().ToList());
        }


    #region == DrawButton ==

        private Color GetPlayButtonColor() {
            
            if(particleManager != null && particleManager.IsPlaying)
                return ButtonColor.GetPlayColor();

            return ButtonColor.GetNormalColor();
        }

        private Color GetNormalColor() {
            return ButtonColor.GetNormalColor();
        }

    #endregion

    #endregion
    }
}
