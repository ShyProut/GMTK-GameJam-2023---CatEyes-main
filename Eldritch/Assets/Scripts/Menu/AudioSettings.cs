using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup sfxMixerGroup;
    [SerializeField] private string musicParameter = "MusicVolume";
    [SerializeField] private string sfxParameter = "SFXVolume";
    [SerializeField] private Slider mainVolumeSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private float maxVolume = 0f;
    private float minVolume = -80f;

    // Start is called before the first frame update
    void Start()
    {
        mainVolumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
        musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        sfxSlider.onValueChanged.AddListener(ChangeSFXVolume);
    }

    private void ChangeMasterVolume(float volume)
    {
        float adjustedVolume = Mathf.Lerp(minVolume, maxVolume, volume);
        audioMixer.SetFloat("MasterVolume", adjustedVolume);
    }

    private void ChangeMusicVolume(float volume)
    {
        float adjustedVolume = Mathf.Lerp(minVolume, maxVolume, volume);
        audioMixer.SetFloat(musicParameter, adjustedVolume);
    }
    private void ChangeSFXVolume(float volume)
    {
        float adjustedVolume = Mathf.Lerp(minVolume, maxVolume, volume);
        audioMixer.SetFloat(sfxParameter, adjustedVolume);
    }

}
