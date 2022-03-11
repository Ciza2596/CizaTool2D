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
        public void Play() {
            if(!gameObject.activeSelf)
                return;
            
            particleManager.Stop();
            particleManager.Play();
        }
        
        [PropertyOrder(35)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public void Stop() {
            particleManager.Stop();
        }
        
    #endregion

    #region === Awake, Update ===

        private void Awake() {
            CheckParticleManager();
            particleManager.Stop();
        }
        
        private void OnValidate() {
            CheckParticleManager();
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

        private Color GetUpdateSettingsButtonColor() {
            if (particleManager != null && particleManager.HasParticles)
                return ButtonColor.GetNormalColor();
            
            return ButtonColor.GetUpdateSettingsColor();
        }

        private Color GetNormalColor() {
            return ButtonColor.GetNormalColor();
        }

    #endregion

    #endregion
    }
}
