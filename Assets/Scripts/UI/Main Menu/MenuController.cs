using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    //MAIN MENU
    [Header("Levels To Load")]
    public string _PlayGame;
    
    public void PlayBtn()
    {
        SceneManager.LoadScene(_PlayGame);
    }
    
    public void Quit_YesBtn()
    {
        Application.Quit();
    }
    
    
    //VOLUME SETTINGS
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null; 
    [SerializeField] private Slider volumeSlider = null;
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //StartCoroutine(Confirmation());
    }
    
    public void VolumeBack()
    {
        float volume = PlayerPrefs.GetFloat("masterVolume");
        volumeTextValue.text = volume.ToString("0.0");
        volumeSlider.value = volume;
    }
    
    //GAMEPLAY SETTINGS
    [Header("Gameplay Settings")] 
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;
    public float mainControllerSen = 1;
    
    public void SetControllerSen(float sensitivity)
    {
        mainControllerSen = sensitivity;
        controllerSenTextValue.text = sensitivity.ToString("0.0");
    }
    
    public void GameplayApply()
    {
        //IF WE DO THE INVERTY TOGGLE
        /*if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
            //INVERT Y
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
            //DONT INVERT Y
        }*/

        PlayerPrefs.SetFloat("masterSensi", mainControllerSen);
        //StartCoroutine(Confirmation());
    }
    
    public void GameplayBack()
    {
        float sensi = PlayerPrefs.GetFloat("masterSensi");
        controllerSenTextValue.text = sensi.ToString("0.0");
        controllerSenSlider.value = sensi;
        
        //IF WE DO THE INVERTY TOGGLE
        /*int ToggleY = PlayerPrefs.GetInt("masterInvertY");
        if (ToggleY == 1)
        {
            invertYToggle.isOn = true;
        }
        else
        {
            invertYToggle.isOn = false;
        }*/
    }
}
