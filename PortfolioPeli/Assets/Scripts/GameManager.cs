// GameManager script
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Player player;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;

    [SerializeField] private Button retryButton;
    [SerializeField] private Button overMenuButton;
    [SerializeField] private Button vicMenuButton;
    [SerializeField] private Button settingsButton; 

    [SerializeField] private GameObject gameOverObject;
    [SerializeField] private GameObject victoryObject;
    [SerializeField] private GameObject settingsObject; 

    [SerializeField] private TextMeshProUGUI victoryScoreText;
    [SerializeField] private TextMeshProUGUI victoryLivesText;
    [SerializeField] private TextMeshProUGUI victoryFinalScoreText;

    [SerializeField] private Slider sfxSlider; 
    [SerializeField] private Slider musicSlider;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private AudioSource musicAudioSource;

    private bool isSettingsOpen = false;

    [SerializeField] private GameObject[] waveSets;

    void Start()
    {
        instance = this;
        player = FindAnyObjectByType<Player>();

        retryButton.onClick.AddListener(RetryGame);
        overMenuButton.onClick.AddListener(GoToMainMenu);
        vicMenuButton.onClick.AddListener(GoToMainMenu);
        settingsButton.onClick.AddListener(ToggleSettings); 

        gameOverObject.SetActive(false);
        victoryObject.SetActive(false);
        settingsObject.SetActive(false);

        sfxAudioSource = GetComponent<AudioSource>(); 
        musicAudioSource = GetComponent<AudioSource>(); 

        if (sfxSlider != null)
        {
            sfxSlider.value = sfxAudioSource.volume;
            sfxSlider.onValueChanged.AddListener(UpdateSFXVolume);
        }

        if (musicSlider != null)
        {
            musicSlider.value = musicAudioSource.volume;
            musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
        }

        if (victoryScoreText != null)
        {
            victoryScoreText.text = "";
        }

        if (settingsObject != null)
        {
            settingsObject.SetActive(isSettingsOpen);
        }
    }

    void Update()
    {
        if (!isSettingsOpen) 
        {
            UpdateUI(player.playerScore);
            UpdateUI(player.health);

            if (player.health <= 0)
            {
                GameOver();
            }

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log("Number of Enemies: " + enemies.Length);

            if (enemies.Length == 0)
            {
                Victory();
            }
        }
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

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        gameOverObject.SetActive(true);
    }

    private void Victory()
    {
        victoryObject.SetActive(true);
        int healthPoints = (int)(player.health * 500);

        float finalTally = healthPoints + player.playerScore;

        if (victoryScoreText != null)
        {
            victoryScoreText.text = "Score: " + player.playerScore.ToString();
            victoryLivesText.text = "Lives: " + player.health.ToString();
            victoryFinalScoreText.text = "Final Score: " + finalTally;
        }
    }

    public void ToggleSettings()
    {
        isSettingsOpen = !isSettingsOpen;
        settingsObject.SetActive(isSettingsOpen);

        Time.timeScale = isSettingsOpen ? 0 : 1;
    }

    public void OpenSettings()
    {
        if (settingsObject != null)
        {
            settingsObject.SetActive(!settingsObject.activeSelf);
        }
    }

    public void UpdateSFXVolume(float volume)
    {
        sfxAudioSource.volume = volume;
    }

    public void UpdateMusicVolume(float volume)
    {
        musicAudioSource.volume = volume;
    }
}
