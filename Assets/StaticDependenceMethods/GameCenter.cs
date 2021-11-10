using UnityEngine;


namespace StaticDependenceMethods
{
    public class GameCenter : MonoBehaviour
    {
        private Enemy _enemyA;
        private Enemy _enemyB;

        void Start()
        {
            EnemySetting enemySetting = new EnemySetting("Dick");
           //用static 的方法可以只注入一次 
           Enemy.SetEnemySetting(enemySetting);

            _enemyA = new Enemy();
            _enemyB = new Enemy();
            _enemyA.Say();
            _enemyB.Say();


        }
    }
}
