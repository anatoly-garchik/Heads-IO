using _Scripts.CommonCharacterComponents;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private PointsStorage _pointsStorage;
        [SerializeField] private DeathHandler _deathHandler;
        
        public PointsStorage PointsStorage => _pointsStorage;
        public DeathHandler DeathHandler => _deathHandler;
    }
}
