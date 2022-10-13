using System.Collections.Generic;

namespace _Scripts.Enemy
{
    public interface IEnemyContainer
    {
        public void AddEnemy(Enemy enemy);
        public List<Enemy> GetAllEnemy();
    }
}