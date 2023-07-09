using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject audioSettingsPanel;
    [SerializeField] private GameObject videoSettingsPanel;
    [SerializeField] private GameObject buttonSettingsPanel;

    public void CloseSettings()
    {
        // Activate the settings canvas
        mainMenuCanvas.SetActive(true);
        // Deactivate the main menu canvas
        settingsCanvas.SetActive(false);
    }

    public void AudioSettings()
    {
        // Activate the audio setting Panel
        audioSettingsPanel.SetActive(true);

        //Deactivate other panels
        videoSettingsPanel.SetActive(false);
        buttonSettingsPanel.SetActive(false);

    }

    public void VideoSettings()
    {
        // Activate the video setting panel
        videoSettingsPanel.SetActive(true);

        // Deactivate other panels
        audioSettingsPanel.SetActive(false);
        buttonSettingsPanel.SetActive(false);
    }

    public void ButtonSettings()
    {
        // Activate the setting panel
        buttonSettingsPanel.SetActive(true);

        // Deactivate other panels
        audioSettingsPanel.SetActive(false);
        videoSettingsPanel.SetActive(false);
        
    }
}
