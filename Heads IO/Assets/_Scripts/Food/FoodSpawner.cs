using System.Collections.Generic;
using _Scripts.Factory;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace _Scripts.Food
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField, Range(0, 100)] private float _rangeToSpawnFood;
        [SerializeField] private int _maxFoodAmount;

        private readonly List<Food> _foods = new List<Food>();

        private GameFactory _gameFactory;

        [Inject]
        private void Construct(GameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start()
        {
            SpawnAllFoodInStartGame();
        }

        public List<Transform> GetAllFoodItems()
        {
            List<Transform> foodPositions = new List<Transform>(_foods.Count);

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

            Food food = _gameFactory.CreateFood(spawnPosition, rotation, transform);
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
