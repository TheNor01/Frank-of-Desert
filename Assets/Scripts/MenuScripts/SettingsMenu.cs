using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    [SerializeField] Slider volumeSlider;

    public void Awake()
    {
        SetResolution();
    }


    public void Start() {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        SetDefaultQuality();

       // Debug.Log("Attivo s");
        SetVolume(volumeSlider.value);
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        int hdIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height + "  " + resolutions[i].refreshRate + "hz";
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height) {
                currentResolutionIndex = i;
            }

            if (resolutions[i].height == 1024) {
                hdIndex = i;
            }
        }

        options.RemoveRange(0, hdIndex);

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetResolution()  //overload di SetResolution
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }



    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }

    public void SetDefaultQuality()
    {
        SetQuality(2); //LOW
    }

    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
