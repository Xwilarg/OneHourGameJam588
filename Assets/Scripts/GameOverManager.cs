using TMPro;
using UnityEngine;

namespace OneHourGameJam588
{
    public class GameOverManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _killText;

        [SerializeField]
        private GameObject _cg;

        private void Awake()
        {
            if (GameManager.KillCount == 0)
            {
                _killText.text = $"You killed 0 gobelin :(\nTry moving your weapon around";
                _cg.SetActive(false);
            }
            else if (GameManager.KillCount == 1)
            {
                _killText.text = $"You killed 1 gobelin\nThat's a good start!";
                _cg.SetActive(false);
            }
            else if (GameManager.KillCount < 40)
            {
                _killText.text = $"You killed {GameManager.KillCount} gobelins\nTry to survive longer for a reward";
                _cg.SetActive(false);
            }
            else
            {
                _killText.text = $"You killed {GameManager.KillCount} gobelins";
                _cg.SetActive(true);
            }
        }
    }
}
