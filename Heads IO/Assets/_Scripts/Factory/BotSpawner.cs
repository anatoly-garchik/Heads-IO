using _Scripts.Bot;
using UnityEngine;
using Zenject;

namespace _Scripts.Factory
{
    public class BotSpawner : MonoBehaviour
    {
        [SerializeField] private BotMoveHandler[] _botPrefabs;
        [SerializeField] private Player.Player _player;
        [SerializeField] private int _rangeToSpawnBot;
        [SerializeField] private int _amountBots;

        [Inject] private DiContainer _diContainer;
        
        private void Start()
        {
            SpawnFood();
        }

        [ContextMenu("Spawn food")]
        public void SpawnFood()
        {
            for (int i = 0; i < _amountBots; i++)
            {
                BotMoveHandler newBot = _diContainer.InstantiatePrefabForComponent<BotMoveHandler>(_botPrefabs[Random.Range(0, _botPrefabs.Length)]);
                newBot.Init(_player);
                newBot.transform.position = new Vector3(Random.Range(-_rangeToSpawnBot, _rangeToSpawnBot), 0.5f,
                    Random.Range(-_rangeToSpawnBot, _rangeToSpawnBot));
            }
        }
    }
}
