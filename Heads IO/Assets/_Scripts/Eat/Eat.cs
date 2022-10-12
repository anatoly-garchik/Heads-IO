using UnityEngine;

namespace _Scripts.Eat
{
    public class Eat : MonoBehaviour
    {
        [SerializeField] private int _points;

        public int Points => _points;
    }
}
