using UnityEngine.SceneManagement;

namespace _Scripts.UI.View
{
    public class GameOverView : View
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}
