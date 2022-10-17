using System;

namespace _Scripts.Services.LoadScene
{
    public interface ISceneLoader
    {
        public void LoadScene(string sceneName, Action onLoaded);
    }
}