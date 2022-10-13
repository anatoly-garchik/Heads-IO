using _Scripts.CommonCharacterComponents;
using _Scripts.Enemy;
using UnityEngine;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PointsStorage _pointsStorage;
        [SerializeField] private DeathHandler _deathHandler;

        public PointsStorage PointsStorage => _pointsStorage;
        public DeathHandler DeathHandler => _deathHandler;
    }
}
