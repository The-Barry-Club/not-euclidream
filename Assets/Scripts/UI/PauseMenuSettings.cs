using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class PauseMenuSettings : MonoBehaviour
{
    [Header("Settings Menu")] 
    public GameObject SettingsMenu;
    public GameObject BackBtn;

    [Header("Popups")] 
    public GameObject pauseMenuUI; 
    public GameObject GraphicsPopup;
    public GameObject SoundPopup;
    public GameObject GameplayPopup;

    [Header("Controls Menu")] 
    public GameObject ControlsScene;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            int scene = PlayerPrefs.GetInt("sceneloaded");
            switch (scene)
            {
                case 2:
                    GraphicsPopup.SetActive(false);
                    SettingsMenu.SetActive(true);
                    PlayerPrefs.SetInt("sceneloaded", 1);
                    break;
                case 3:
                    SoundPopup.SetActive(false);
                    SettingsMenu.SetActive(true);
                    PlayerPrefs.SetInt("sceneloaded", 1);
                    break;
                case 4:
                    GameplayPopup.SetActive(false);
                    SettingsMenu.SetActive(true);
                    PlayerPrefs.SetInt("sceneloaded", 1);
                    break;
                case 41:
                    ControlsScene.SetActive(false);
                    SettingsMenu.SetActive(true);
                    PlayerPrefs.SetInt("sceneloaded", 1);
                    break;
                case 1:
                    SettingsMenu.SetActive(false);
                    pauseMenuUI.SetActive(true);
                    PlayerPrefs.SetInt("sceneloaded", 0);
                    break;
                default:
                    break;
            }
        }
    }

    //GRAPHICS SETTINGS
    public void GraphicsSettingsBtn()
    {
        SettingsMenu.SetActive(false);
        GraphicsPopup.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 2);
    }
    
    //SOUND SETTINGS
    public void SoundSettingsBtn()
    {
        SettingsMenu.SetActive(false);
        SoundPopup.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 3);
    }
    
    //GAMEPLAY SETTINGS
    public void GameplaySettingsBtn()
    {
        SettingsMenu.SetActive(false);
        GameplayPopup.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 4);
    }

    public void ControlsBtn()
    {
        GameplayPopup.SetActive(false);
        ControlsScene.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 41);
    }

    public void ControlsQuitBtn()
    {
        ControlsScene.SetActive(false);
        GameplayPopup.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 4);
    }
    
}
