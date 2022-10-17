using System;
using _Scripts.Services.ScreenFade;
using UnityEngine.SceneManagement;

namespace _Scripts.Services.LoadScene
{
    public class SceneLoader : ISceneLoader
    {
        private IScreenFader _screenFader;

        public SceneLoader(IScreenFader screenFader)
        {
            _screenFader = screenFader;
        }
        
        public void LoadScene(string sceneName, Action onLoaded)
        {
            _screenFader.ShowCurtain(() =>
            {
                SceneManager.LoadSceneAsync(sceneName).completed += operation =>
                {
                    _screenFader.HideCurtain(() => onLoaded?.Invoke());
                };
            });
            
        }
    }
}
