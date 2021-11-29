using System.Linq.Expressions;

namespace CizaTool2D
{
    public interface IAnimator
    {
        bool GetIsCurrentState(int    index, string currentStateName);
        bool GetIsTagCurrentState(int index, string tagName);

        public float GetCurrentNormalizeTime(int index);

        public void Play(int       index, string name, bool   loop, float timeScale);
        public void PlayAtTime(int index, float  time, string name, bool  loop, float timeScale);

        public void PlayAtNormalizeTime(int index, float normalizeTime, string name, bool loop, float timeScale);
    }
}
