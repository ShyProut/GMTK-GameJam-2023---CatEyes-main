using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class NextLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private string gameSceneName;
    [SerializeField] private GameObject circleObject;
    [SerializeField] private GameObject boxObject;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private string nextLevelActionMap;
    [SerializeField] private PauseMenuManager pauseMenuManager;

    private bool hasReachedBox = false;
    private bool isUIActive = false;
    private EventSystem eventSystem;

    private void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();
    }

    private void Update()
    {
        if (!hasReachedBox)
        {
            // Check if the circle has reached the box
            float distance = Vector2.Distance(circleObject.transform.position, boxObject.transform.position);
            if (distance < 0.1f) // Adjust the threshold as needed
            {
                hasReachedBox = true;
                ActivateNextLevelPanel();
                FreezeGameplayTime();
                SwitchActionMap(nextLevelActionMap);
                EnableUIInteraction();
                
            }
        }
    }

    private void ActivateNextLevelPanel()
    {
        // Activate the next level panel
        nextLevelPanel.SetActive(true);
    }

    public void NextLevel()
    {
        // Reset time scale before loading the next scene
        Time.timeScale = 1f;

        // Load the next level
        SceneManager.LoadScene(gameSceneName);
    }

    private void FreezeGameplayTime()
    {
        Time.timeScale = 0f;
    }

    private void SwitchActionMap(string actionMapName)
    {
        if (playerInput != null)
        {
            playerInput.SwitchCurrentActionMap(actionMapName);
        }
    }

    private void EnableUIInteraction()
    {
        isUIActive = true;
        eventSystem.SetSelectedGameObject(nextLevelPanel); // Set the selected UI element
    }

    private void UpdateUIInteraction()
    {
        if (isUIActive && eventSystem.currentSelectedGameObject == null)
        {
            eventSystem.SetSelectedGameObject(nextLevelPanel); // Set the selected UI element if none is selected
        }
    }

    private void LateUpdate()
    {
        if (isUIActive)
        {
            Time.timeScale = 0f; // Keep time frozen while UI is active
            UpdateUIInteraction();
        }
    }
}
