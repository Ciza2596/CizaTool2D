using System.Collections.Generic;
using CizaTool2D.Utility.Component;
using UnityEngine;

namespace CizaTool2D.EffectPlayer.Package
{
    public class ParticleManager
    {
        public ParticleManager(List<ParticleSystem> particles) {
            this.particles = particles;
            
            if(this.particles != null)
                foreach(var particle in this.particles){
                    var main = particle.main;
                    main.duration = 1;
                }
        }

        private List<ParticleSystem> particles;

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
        
        public void SetLoop(bool loop) {
            Loop = loop;
            foreach(var particle in particles){
                var main = particle.main;
                main.loop     = loop;
            }
        }

        public void SetComponents(List<Component> components) {
            foreach(var particle in particles)
                particle.gameObject.SetActive(false);

            for(int i = 0; i < components.Count; i++){
                var newParticle = components[i] as ParticleSystem;
                var particle    = particles[i];
                if(newParticle != null && particle != null){
                    particle.CopyParticle(newParticle);
                    particle.gameObject.SetActive(true);
                }
            }
        }

    #endregion

    #region === Action ===
        
        public void Play() {
            if(!HasParticles)
                return;

            foreach(var particle in particles)
                particle.Play();
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
