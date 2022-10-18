using System;
using System.Collections.Generic;

namespace _Scripts.Enemy
{
    public interface IEnemyContainer
    {
        public event Action EnemyRemoved;
        public void AddEnemy(Enemy enemy);
        public void ClearEnemyContainer();
        public List<Enemy> GetAllEnemy();
    }
}