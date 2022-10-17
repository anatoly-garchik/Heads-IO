using System;
using UnityEngine.SceneManagement;

namespace _Scripts.Services.LoadScene
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName, Action onLoaded)
        {
            SceneManager.LoadSceneAsync(sceneName).completed += operation =>
            {
                onLoaded?.Invoke();
            };
        }
    }
}
