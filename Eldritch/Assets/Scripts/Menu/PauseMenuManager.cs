using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject quitConfirmationPanel;
    public PlayerInput playerInput;
    public string playerInputMap = "PlayerInput";
    public string pauseMenuMap = "PauseMenu";
    public string mainMenuScene;
    public InputActionReference pauseAction;
    public InputActionReference unpauseAction;
    [SerializeField] private string currentSceneName;
    private bool isPaused = false;
    private bool isConfirmationActive = false;
    private bool isPauseActionTriggered = false;

    private void OnEnable()
    {
        pauseAction.action.Enable();
        unpauseAction.action.Enable();
        pauseAction.action.performed += OnPauseActionTriggered;
        unpauseAction.action.performed += OnUnpauseActionTriggered;
    }

    private void OnDisable()
    {
        pauseAction.action.Disable();
        unpauseAction.action.Disable();
        pauseAction.action.performed -= OnPauseActionTriggered;
        unpauseAction.action.performed -= OnUnpauseActionTriggered;
    }

    private void OnPauseActionTriggered(InputAction.CallbackContext context)
    {
        if (!isPauseActionTriggered)
        {
            isPauseActionTriggered = true;
            if (!isPaused)
            {
                SetPauseState(true);
                SwitchActionMap(pauseMenuMap);
            }
        }
    }

    private void OnUnpauseActionTriggered(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            SetPauseState(false);
            ResumeGame();
        }
    }

    public void RestartScene()
    {
        // Reset time scale before reloading the scene
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void SetPauseState(bool paused)
    {
        isPaused = paused;
        Time.timeScale = paused ? 0f : 1f;
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;
        pauseMenuPanel.SetActive(paused);
    }

    private void SwitchActionMap(string actionMapName)
    {
        playerInput.SwitchCurrentActionMap(actionMapName);
    }

    public void ResumeGame()
    {
        SetPauseState(false);
        isConfirmationActive = false;
        quitConfirmationPanel.SetActive(false);
        SwitchActionMap(playerInputMap);
        isPauseActionTriggered = false;
    }

    public void ConfirmQuitGame()
    {
        isConfirmationActive = true;
        quitConfirmationPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);

    }

    public void CancelQuitGame()
    {
        isConfirmationActive = false;
        quitConfirmationPanel.SetActive(false);
        pauseMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {

        SceneManager.LoadScene(mainMenuScene);
    }
}
