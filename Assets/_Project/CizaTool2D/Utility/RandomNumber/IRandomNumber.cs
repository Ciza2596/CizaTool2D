namespace CizaTool2D.Utility.RandomNumber
{
    public interface IRandomNumber
    {
        public void Init();

        public int GetRandomNumberForTwo();

        public int GetRandomNumberForMoreThree(int maxCount);
    }
}
