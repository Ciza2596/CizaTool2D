using System.Collections.Generic;
using System.Linq;
using CizaTool2D.EffectPlayer.Package;
using CizaTool2D.Utility.Editor;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CizaTool2D.EffectPlayer
{
    public class AnimEffectPlayer: ISubEffectPlayerOperation
    {
        private AnimManager animManager;
        
    #region === Operation Group ===

        [PropertyOrder(20)]
        [BoxGroup("Operation")]
        [PropertySpace]
        [GUIColor("GetPlayButtonColor")]
        [Button]
        public override void Play() {
            if(!gameObject.activeSelf)
                return;
            
            animManager.Stop();
            animManager.Play();
        }
        
        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public override void Stop() {
            animManager.Stop();
        }
        
    #endregion
        
    #region === Set, Get ===
        
        public List<Component> GetComponents() {
            CheckAnimManager();
            return animManager.GetComponents();
        }

    #region ===  ISubEffectPlayer ===

        public override ISubEffectPlayer GetSubEffectPlayer() {
            return this;
        }

    #endregion

    #region === ISubEffectPlayerOperation ===

        public override void SetSubEffectPlayer(ISubEffectPlayer isubEffectPlayer) {
            if(isubEffectPlayer is AnimEffectPlayer animEffectPlayer)
                animManager.SetComponents(animEffectPlayer.GetComponents());
        }

        public override void SetLoop(bool loop) {
            animManager.SetLoop(loop);
        }
        
        public override bool GetIsPlaying() {
            return animManager.IsPlaying;
        }

    #endregion

    #endregion

    #region === Awake, Update ===

        private void Awake() {
            CheckAnimManager();
            animManager.Stop();
        }

        void Update() {
            animManager.Update();
        }

    #endregion
        
    #region === Private Methods ===
        
        private void CheckAnimManager() {
            if(animManager != null)
                return;
            animManager = new AnimManager(gameObject.GetComponentsInChildren<Animator>().ToList());
        }
        
    #region == DrawButton ==

        private Color GetPlayButtonColor() {
            
            if(animManager != null && animManager.IsPlaying)
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
