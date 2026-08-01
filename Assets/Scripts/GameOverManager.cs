using TMPro;
using UnityEngine;

namespace OneHourGameJam588
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _killText;

        private void Awake()
        {
            if (GameManager.KillCount == 0)
            {
                _killText.text = $"You killed 0 gobelin :(\nTry moving your weapon around";
            }
            else if (GameManager.KillCount == 1)
            {
                _killText.text = $"You killed 1 gobelin\nThat's a good start!";
            }
            else
            {
                _killText.text = $"You killed {GameManager.KillCount} gobelins";
            }
        }
    }
}
