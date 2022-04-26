using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    [Header("General Settings")] 
    [SerializeField] private bool canUse = false;

    [SerializeField] private MenuController menuController;

    [Header("Volume Settings")] 
    [SerializeField] private TMP_Text volumeTextValue = null;

    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness Settings")]
    [SerializeField] private TMP_Text brightnessTextValue = null;

    [SerializeField] private Slider brightnessSlider = null;
    
    [Header("Quality Level Settings")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Header("Fullscreen Settings")] 
    [SerializeField] private Toggle fullScreenToggle;

    [Header("Sensitivity Settings")]
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;
    
    
    [Header("Invert Y Settings")]
    [SerializeField] private Toggle invertYToggle = null;

    private void Awake()
    {
        if (canUse)
        {
            //VOLUME
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                float basicVolume = 0.5f;
                volumeTextValue.text = basicVolume.ToString("0.0");
                volumeSlider.value = basicVolume;
            }
            
            /*
            //QUALITY
            if (PlayerPrefs.HasKey(masterQuality))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                localQuality.Dropdown.value = localQuality;
                QualitySettings.SSetQualityLevel(localQuality);
            }*/
            
            //FULLSCREEN
            if (PlayerPrefs.HasKey("masterFullScreen"))
            {
                int localFullScreen = PlayerPrefs.GetInt("masterFullScreen");

                if (localFullScreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }
            }
            
            //BRIGHTNESS
            if (PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                brightnessTextValue.text = localBrightness.ToString("0.0");
                brightnessSlider.value = localBrightness;
                //modify the brightness
            }
            
            //SENSITIVITY
            if (PlayerPrefs.HasKey("masterSen"))
            {
                float localSensitivity = PlayerPrefs.GetFloat("masterSen");

                controllerSenTextValue.text = localSensitivity.ToString("0");
                controllerSenSlider.value = localSensitivity;
                menuController.mainControllerSen = localSensitivity;
            }
        }
    }
}
