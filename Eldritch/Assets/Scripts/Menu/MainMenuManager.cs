using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;

    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenSettings()
    {
        // Activate the settings canvas
        settingsCanvas.SetActive(true);
        // Deactivate the main menu canvas
        mainMenuCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}
