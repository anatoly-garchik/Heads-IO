using _Scripts.CommonCharacterComponents;
using UnityEngine;

namespace _Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PointsStorage _pointsStorage;
        [SerializeField] private DeathHandler _deathHandler;
        [SerializeField] private JumpActivator _jumpActivator;
        [SerializeField] private GrowthController _growthController;

        public PointsStorage PointsStorage => _pointsStorage;
        public DeathHandler DeathHandler => _deathHandler;
        public JumpActivator JumpActivator => _jumpActivator;
        public GrowthController GrowthController => _growthController;
    }
}
