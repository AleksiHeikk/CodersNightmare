using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Player player;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;


    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        UpdateUI(player.playerScore);
        UpdateUI(player.health);
    }

    public void UpdateUI(float playerScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + player.playerScore.ToString();
        }

        if (livesText != null)
        {
            livesText.text = "Lives: " + player.health.ToString();
        }
    }

    // vois heitt‰‰ t‰nne ne menu UI asiat (ehk‰)

}
