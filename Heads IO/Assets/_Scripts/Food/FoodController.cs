using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Scripts.Food
{
    public class FoodController : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float _rangeToSpawnFood;
        [SerializeField] private int _maxFoodAmount;

        private readonly List<Food> _foods = new List<Food>();
        
        private FoodFactory _foodFactory;

        [Inject]
        private void Construct(FoodFactory foodFactory)
        {
            _foodFactory = foodFactory;
        }

        private void Start()
        {
            SpawnAllFoodInStartGame();
        }

        public List<Transform> GetAllFoodItems()
        {
            List<Transform> foodPositions = new List<Transform>();

            foreach (var food in _foods)
                foodPositions.Add(food.transform);

            return foodPositions;
        }

        private void SpawnAllFoodInStartGame()
        {
            for (int i = 0; i < _maxFoodAmount; i++)
                SpawnFood();
        }

        private void SpawnFood()
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-_rangeToSpawnFood, _rangeToSpawnFood), 0,
                Random.Range(-_rangeToSpawnFood, _rangeToSpawnFood));
                
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360),0);

            Food food = _foodFactory.CreateFood(spawnPosition, rotation, transform);
            food.FoodTaken += OnTakeFood;
            _foods.Add(food);
        }

        private void OnTakeFood(Food food)
        {
            food.FoodTaken -= OnTakeFood;
            _foods.Remove(food);
            Destroy(food.gameObject);
            SpawnFood();
        }
    }
}
