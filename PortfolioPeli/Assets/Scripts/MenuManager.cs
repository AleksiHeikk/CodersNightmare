using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Need to add this for scene management
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        // Attach functions to the onClick events
        playButton.onClick.AddListener(OpenGameScene);
        settingsButton.onClick.AddListener(OpenSettingsScene);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void OpenGameScene()
    {
        // Load the game scene
        SceneManager.LoadScene("CodersNightmare");
    }

    public void OpenSettingsScene()
    {
        // Load the settings scene
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        // Quit the application (only works in standalone builds)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
