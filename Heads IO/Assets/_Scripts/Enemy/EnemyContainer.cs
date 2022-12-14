using System;
using System.Collections.Generic;
using System.Linq;

namespace _Scripts.Enemy
{
    public class EnemyContainer : IEnemyContainer
    {
        private readonly List<Enemy> _enemies = new List<Enemy>();

        public event Action EnemyRemoved;

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
            
            Action deathAction = null;
            deathAction = () =>
            {
                enemy.DeathHandler.Died -= deathAction;
                RemoveEnemy(enemy);
            };
            enemy.DeathHandler.Died += deathAction;
        }

        public void ClearEnemyContainer()
        {
            for (int i = _enemies.Count - 1; i >= 0; i--)
                _enemies.Remove(_enemies[i]);
        }
        
        public List<Enemy> GetAllEnemy() => 
            _enemies.ToList();

        private void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
            EnemyRemoved?.Invoke();
        }
    }
}
 