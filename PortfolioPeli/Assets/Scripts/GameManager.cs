using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void UpdateScoreUI(float playerScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + player.playerScore.ToString();
        }
    }
}
