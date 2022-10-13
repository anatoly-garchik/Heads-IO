using UnityEngine;

namespace _Scripts.CommonCharacterComponents
{
    public class PointsStorage : MonoBehaviour
    {
        [SerializeField] private GrowthController _growthController;
        [SerializeField] private int _defaultPoints;
        
        public int AmountPoints { get; private set; }

        private void Awake()
        {
            AmountPoints = _defaultPoints;
        }

        public void AddPoints(int points)
        {
            AmountPoints += points;
            _growthController.IncreaseCharacter(points);
        }
    }
}
