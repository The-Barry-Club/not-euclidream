using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _PlayGame;

    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Gameplay Settings")] 
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;
    public float mainControllerSen = 1;

    [Header("Toggle Settings")] 
    [SerializeField] private Toggle invertYToggle = null;

    [Header("Graphics Settings")] 
    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private Slider brightnessSlider = null;
    private int qualityLevel;
    private bool isFullScreen;
    private float brightnessLevel;

    [Header("Resolution")] 
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    public void PlayBtn()
    {
        SceneManager.LoadScene(_PlayGame);
    }

    public void Quit_YesBtn()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void SetControllerSen(float sensitivity)
    {
        mainControllerSen = sensitivity;
        controllerSenTextValue.text = sensitivity.ToString("0.0");
    }

    public void SetBrightness(float brightness)
    {
        brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");
    }

    public void SetFullScreen(bool IsFullScreen)
    {
        isFullScreen = IsFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        qualityLevel = qualityIndex;
    }
    
    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", brightnessLevel);
        //change brightness with post processing

        PlayerPrefs.SetInt("masterQuality", qualityLevel);
        QualitySettings.SetQualityLevel(qualityLevel);

        PlayerPrefs.SetInt("masterFullScreen", (isFullScreen ? 1 : 0));
        Screen.fullScreen = isFullScreen;

        StartCoroutine(Confirmation());
    }

    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
            //INVERT Y
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
            //DONT INVERT Y
        }

        PlayerPrefs.SetFloat("masterSensi", mainControllerSen);
        StartCoroutine(Confirmation());
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(Confirmation());
    }

    public void GrpahicsBack()
    {
        float brightn = PlayerPrefs.GetFloat("masterBrightness");
        brightnessTextValue.text = brightn.ToString("0.0");
        brightnessSlider.value = brightn;
    }

    public void GameplayBack()
    {
        float sensi = PlayerPrefs.GetFloat("masterSensi");
        controllerSenTextValue.text = sensi.ToString("0.0");
        controllerSenSlider.value = sensi;
        int ToggleY = PlayerPrefs.GetInt("masterInvertY");
        if (ToggleY == 1)
        {
            invertYToggle.isOn = true;
        }
        else
        {
            invertYToggle.isOn = false;
        }
    }

    public void VolumeBack()
    {
        float volume = PlayerPrefs.GetFloat("masterVolume");
        volumeTextValue.text = volume.ToString("0.0");
        volumeSlider.value = volume;
    }

    public IEnumerator Confirmation()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(1);
        confirmationPrompt.SetActive(false);
    }
    
}