using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

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

    private bool isSettingsOpen = false;

    [SerializeField] private GameObject[] waveSets;
    [SerializeField] private float timeBetweenWaves = 5f;
    private int currentWaveIndex = 0;
    private bool isWaveActive = false;

    [SerializeField] private GameObject waveCountdown;
    [SerializeField] private Text waveCountdownText;
    private float currentCountdown;
    private bool isCountdownActive = false;

    [SerializeField] private AudioSource backgroundAudio;

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


        if (victoryScoreText != null)
        {
            victoryScoreText.text = "";
        }

        if (settingsObject != null)
        {
            settingsObject.SetActive(isSettingsOpen);
        }

        StartCoroutine(StartWaveAfterDelay());
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

            if (isWaveActive)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                Debug.Log("Number of Enemies: " + enemies.Length);

                if (enemies.Length == 0)
                {
                    if (currentWaveIndex == waveSets.Length)
                    {
                        Victory();
                    }
                    else
                    {
                        // Start countdown after winning the wave
                        if (!isCountdownActive)
                        {
                            StartCoroutine(ShowCountdownAndStartNextWave());
                        }
                    }
                }
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
        backgroundAudio.Stop();
    }

    private void Victory()
    {
        victoryObject.SetActive(true);
        backgroundAudio.Stop();
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

    private IEnumerator StartWaveAfterDelay()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        StartWave();
    }

    private void StartWave()
    {
        isWaveActive = true;

        if (currentWaveIndex < waveSets.Length)
        {
            GameObject waveSet = waveSets[currentWaveIndex];
            if (waveSet != null)
            {
                waveSet.SetActive(true);
            }
        }

        currentWaveIndex++;
    }

    private IEnumerator ShowCountdownAndStartNextWave()
    {
        isCountdownActive = true;
        waveCountdown.SetActive(true);

        currentCountdown = timeBetweenWaves;

        while (currentCountdown > 0)
        {
            UpdateCountdownText();
            yield return null;
        }

        waveCountdown.SetActive(false);
        isCountdownActive = false;


        StartWave();
    }

    private void UpdateCountdownText()
    {
        if (waveCountdownText != null)
        {
            waveCountdownText.text = "Next Wave in: " + Mathf.CeilToInt(currentCountdown).ToString();
        }
        currentCountdown -= Time.deltaTime;
    }
}
