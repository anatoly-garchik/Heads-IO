using UnityEngine;
using Zenject;

namespace _Scripts.Food
{
    public class FoodFactory : MonoBehaviour
    {
        [SerializeField] private Food[] _foodPrefabs;

        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Food CreateFood(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            return _diContainer.InstantiatePrefabForComponent<Food>(_foodPrefabs[Random.Range(0, _foodPrefabs.Length)], position, rotation, parent);
        }
    }
}