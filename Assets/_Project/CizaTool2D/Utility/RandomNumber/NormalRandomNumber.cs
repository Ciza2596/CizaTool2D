using UnityEngine;

namespace CizaTool2D.Utility.RandomNumber
{
    public class NormalRandomNumber: IRandomNumber
    {
        public NormalRandomNumber() {
            Init();
        }

        public void Init() {
            sameNumberCountForTwo = 0;
            preNumberForTwo       = -1;
            preNumberForThree     = -1;
        }

        private int sameNumberCountForTwo;
        private int preNumberForTwo;

        public int GetRandomNumberForTwo() {
            var randomNumber = Random.Range(0, 2);

            if(randomNumber == preNumberForTwo){
                if(sameNumberCountForTwo > 2){
                    sameNumberCountForTwo = 0;
                    if(randomNumber == 0)
                        randomNumber = 1;
                    else
                        randomNumber = 0;
                }
                else{
                    sameNumberCountForTwo++;
                }
            }
            else{
                sameNumberCountForTwo = 0;
            }

            preNumberForTwo = randomNumber;
            return preNumberForTwo;
        }


        private int preNumberForThree = -1;
        
        public int GetRandomNumberForMoreThree(int maxCount) {
            var randomNumber = Random.Range(0, maxCount);
            
            if(randomNumber == preNumberForThree)
                randomNumber = GetRandomNumberForMoreThree(maxCount);

            preNumberForThree = randomNumber;
            
            return preNumberForThree;
        }
    }
}
