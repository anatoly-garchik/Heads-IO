using _Scripts.CommonCharacterComponents;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private PointsStorage _pointsStorage;
        [SerializeField] private DeathHandler _deathHandler;
        [SerializeField] private AgroMode _agroMode;
        [SerializeField] private EnemyTargetHandler _enemyTargetHandler;
        [SerializeField] private SkullMarkHandler _skullMarkHandler;
        
        public PointsStorage PointsStorage => _pointsStorage;
        public DeathHandler DeathHandler => _deathHandler;
        public AgroMode AgroMode => _agroMode;
        public EnemyTargetHandler EnemyTargetHandler => _enemyTargetHandler;
        public SkullMarkHandler SkullMarkHandler => _skullMarkHandler;
    }
}
