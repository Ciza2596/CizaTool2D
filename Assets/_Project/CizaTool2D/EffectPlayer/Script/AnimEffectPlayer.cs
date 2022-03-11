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
        public void Play() {
            if(!gameObject.activeSelf)
                return;
            
            animManager.Stop();
            animManager.Play();
        }
        
        [PropertyOrder(30)]
        [BoxGroup("Operation")]
        [GUIColor("GetNormalColor")]
        [Button]
        public void Stop() {
            animManager.Stop();
        }
        
    #endregion

    #region === Awake, Update, OnValidate ===

        private void Awake() {
            CheckAnimManager();
            animManager.Stop();
        }

        void Update() {
            animManager.Update();
        }
        
        private void OnValidate() {
            CheckAnimManager();
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

        private Color GetUpdateSettingsButtonColor() {
            if (animManager != null && animManager.HasAnimators)
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
