using UnityEngine;
using Zenject;

namespace _Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameController _gameController;

        [Inject]
        private void Construct(GameController gameController)
        {
            _gameController = gameController;
        }

        private void Start()
        {
            _gameController.Run();
        }
    }
}
