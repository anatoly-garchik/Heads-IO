using System;
using UnityEngine;

namespace _Scripts.CommonCharacterComponents
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
