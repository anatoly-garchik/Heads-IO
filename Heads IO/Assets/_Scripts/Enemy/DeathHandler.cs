using System;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class DeathHandler : MonoBehaviour
    {
        public event Action Died;

        public void Kill()
        {
            Died?.Invoke();
            Destroy(gameObject);
        }
    }
}
