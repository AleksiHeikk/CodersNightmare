using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ssf : MonoBehaviour
{
    [SerializeField] private Button menuButton;

    void Start()
    {
        menuButton.onClick.AddListener(GoToMainMenu);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
