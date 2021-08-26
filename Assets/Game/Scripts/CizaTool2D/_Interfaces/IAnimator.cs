namespace CizaTools2D
{
    public interface IAnimator
    {
        public string GetAnimName();
        
        public void PlayAnim(string name, bool loop, float timeScale, int layer);
    }
}