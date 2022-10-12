using System;
using UnityEngine;

namespace _Scripts.Food
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private int _points;

        public int Points => _points;

        public event Action<Food> FoodTaken;

        public void Take() => 
            FoodTaken?.Invoke(this);
    }
}
