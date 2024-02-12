using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OpenGameScene);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void OpenGameScene()
    {
        // Load the game scene
        SceneManager.LoadScene("CodersNightmare");
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
