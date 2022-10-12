using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Factory
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _foodPrefabs;
        [SerializeField] private int _rangeToSpawnFood;
        [SerializeField] private int _amountFood;
        
        [SerializeField] private List<GameObject> _foods;

        private void Start()
        {
            SpawnFood();
        }

        [ContextMenu("Spawn food")]
        public void SpawnFood()
        {
            for (int i = 0; i < _amountFood; i++)
            {
                GameObject newFood = Instantiate(_foodPrefabs[Random.Range(0, _foodPrefabs.Length)], transform);
                newFood.transform.position = new Vector3(Random.Range(-_rangeToSpawnFood, _rangeToSpawnFood), 0.25f,
                    Random.Range(-_rangeToSpawnFood, _rangeToSpawnFood));

                newFood.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
                _foods.Add(newFood);
            }
        }

        public GameObject GetTargetFood()
        {
            return _foods[Random.Range(0, _foods.Count)];
        }

        public void RemoveFood(GameObject food)
        {
            _foods.Remove(food);
            Destroy(food);
        }
        
        [ContextMenu("Destroy food")]
        public void DestroyFood()
        {
            for (int i = _foods.Count - 1; i >= 0; i--)
            {
                Destroy(_foods[i]);
                _foods.Remove(_foods[i]);
            }
        }
    }
}
