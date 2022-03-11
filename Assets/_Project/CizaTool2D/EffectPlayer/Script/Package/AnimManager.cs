using System.Collections.Generic;
using UnityEngine;

namespace CizaTool2D.EffectPlayer.Package
{
    public class AnimManager
    {
    #region === Constroctor ===

        public AnimManager(List<Animator> animators) {
            if(animators == null)
                Debug.Log("Loading animators failed.");

            this.animators = animators;
        }

    #endregion
        
        private List<Animator> animators = new List<Animator>();
        private bool           isRestart;
        private string         stateName     = "Idle";
        private string         speedRateName = "SpeedRate";
        private float          speedRate     = 1;

    #region === Get ===

        public bool Loop { get; private set; }

        private bool isPlaying;
        public bool IsPlaying {
            get => isPlaying;
            private set {
                isPlaying = value;
            }
        }

        public bool HasAnimators {
            get {
                if(animators.Count > 0)
                    return true;

                Debug.Log("Hasnt animators");
                return false;
            }
        }
        
        public List<Component> GetComponents() {
            if(animators.Count > 0){
                List<Component> components = new List<Component>();
                foreach(var animator in animators)
                    components.Add(animator);

                return components;
            }

            Debug.Log("Animators are null.");
            return null;
        }

    #endregion

    #region === Set ===

        public void SetComponents(List<Component> components) {
            foreach(var anim in animators)
                anim.gameObject.SetActive(false);

            for(int i = 0; i < components.Count; i++){
                var newAnimator = (Animator) components[i];
                animators[i].runtimeAnimatorController = newAnimator.runtimeAnimatorController;
                animators[i].gameObject.SetActive(true);
                Stop();
            }
        }

    #endregion

    #region === Action ===

        public void Play() {
            if(!HasAnimators)
                return;
            isRestart  = true;
            IsPlaying = false;
        }

        public void Stop() {
            if(!HasAnimators)
                return;

            foreach(var animator in animators){
                animator.SetFloat(speedRateName, 0);
                animator.Play(stateName, 0, 0.95f);
            }

            isRestart  = false;
            IsPlaying = false;
        }

        public void Update() {
            if(!HasAnimators)
                return;

            if(isRestart){
                int completeNumber = 0;
                foreach(var animator in animators){
                    if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f){
                        animator.SetFloat(speedRateName, 0);
                        completeNumber++;
                    }
                }

                if(animators.Count == completeNumber){
                    foreach(var animator in animators){
                        animator.SetFloat(speedRateName, speedRate);
                        animator.Play(stateName, 0, 0);
                    }

                    IsPlaying = true;
                    isRestart  = false;
                }

                return;
            }


            if(!Loop && IsPlaying){
                int completeNumber = 0;
                foreach(var animator in animators){
                    if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f){
                        animator.SetFloat(speedRateName, 0);
                        completeNumber++;
                    }
                }

                if(animators.Count == completeNumber){
                    IsPlaying = false;
                }
            }
        }

    #endregion
    }
}
