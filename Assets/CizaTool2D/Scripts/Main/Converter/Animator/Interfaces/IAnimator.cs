using System.Linq.Expressions;

namespace CizaTool2D
{
    public interface IAnimator
    {
        public string GetName(int index);
        
        public float GetTime(int index);

        public float GetNormalizeTime(int index);

        public void Play(int index, string name, bool loop, float timeScale);
        public void PlayAtTime(int index, float time,string name, bool loop, float timeScale);
        
        public void PlayAtNormalizeTime(int index, float normalizeTime,string name, bool loop, float timeScale);
    }
}