using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneHourGameJam588
{
    public class MenuManager : MonoBehaviour
    {
        public void GoToGame()
        {
            SceneManager.LoadScene("Main");
        }

        public void Loose()
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
