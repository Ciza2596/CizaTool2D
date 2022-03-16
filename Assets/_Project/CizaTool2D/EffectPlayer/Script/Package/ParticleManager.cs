using System.Collections.Generic;
using UnityEngine;

namespace CizaTool2D.EffectPlayer.Package
{
    public class ParticleManager
    {
        public ParticleManager(List<ParticleSystem> particles) {
            if(particles == null || particles.Count < 1)
                Debug.Log("Loading particles failed.");
            
            
            this.particles = particles;

            if(this.particles != null)
                SetDuration(4);

            maxParticlesNumber = particles.Count;
        }

        private List<ParticleSystem> particles;
        private int                  maxParticlesNumber;

    #region === Get ===
        

        public bool Loop { get; private set; }

        public bool IsPlaying {
            get {
                foreach(var particle in particles){
                    if(particle.isPlaying)
                        return true;
                }

                return false;
            }
        }

        public bool HasParticles {
            get {
                if(particles.Count > 0)
                    return true;

                Debug.Log("Hasnt particles");
                return false;
            }
        }

        public List<Component> GetComponents() {
            if(particles.Count > 0){
                List<Component> components = new List<Component>();
                foreach(var particle in particles)
                    components.Add(particle);

                return components;
            }

            Debug.Log("Particles are null.");
            return null;
        }

    #endregion

    #region === Set ===

        public void SetDuration(float duration) {
            if(duration < 1)
                return;
            
            foreach(var particle in this.particles){
                var main = particle.main;
                main.duration = duration;
            }
        }

        public void SetLoop(bool loop) {
            Loop = loop;
            foreach(var particle in particles){
                var main = particle.main;
                main.loop     = loop;
            }
        }

        public void SetComponents(List<Component> components) {
            maxParticlesNumber = components.Count;

            for(int i = 0; i < maxParticlesNumber; i++){
                var newParticle = components[i] as ParticleSystem;
                var particle    = particles[i];
                if(newParticle != null && particle != null){
                    UnityEditorInternal.ComponentUtility.CopyComponent(newParticle);
                    UnityEditorInternal.ComponentUtility.PasteComponentValues(particle);
                }
            }
        }

    #endregion

    #region === Action ===
        
        public void Play() {
            if(!HasParticles)
                return;

            for(int i = 0; i < maxParticlesNumber; i++){
                particles[i].Play();
            }
        }

        public void Stop() {
            if(!HasParticles)
                return;

            foreach(var particle in particles){
                particle.Stop();
                particle.Clear();
            }
        }

    #endregion
    }
}
