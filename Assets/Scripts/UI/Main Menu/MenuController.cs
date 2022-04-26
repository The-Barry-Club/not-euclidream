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
}
