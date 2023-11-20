using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Player player;

    [SerializeField] private Text scoreText;


    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void UpdateScoreUI(float playerScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + player.playerScore.ToString("0");
        }
    }
}
