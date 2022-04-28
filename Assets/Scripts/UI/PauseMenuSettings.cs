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
    /*public GameObject SoundSettings;
    public GameObject GraphicsSettings;
    public GameObject GameplaySettings;*/
    public GameObject BackBtn;

    [Header("Popups")] 
    public GameObject GraphicsPopup;
    public GameObject SoundPopup;
    public GameObject GameplayPopup;

    [Header("Controls Menu")] 
    public GameObject ControlsScene;
    
    //GRAPHICS SETTINGS
    public void GraphicsSettingsBtn()
    {
        SettingsMenu.SetActive(false);
        GraphicsPopup.SetActive(true);
    }
    
    //SOUND SETTINGS
    public void SoundSettingsBtn()
    {
        SettingsMenu.SetActive(false);
        SoundPopup.SetActive(true);
    }
    
    //GAMEPLAY SETTINGS
    public void GameplaySettingsBtn()
    {
        SettingsMenu.SetActive(false);
        GameplayPopup.SetActive(true);
    }

    public void ControlsBtn()
    {
        GameplayPopup.SetActive(false);
        ControlsScene.SetActive(true);
    }

    public void ControlsQuitBtn()
    {
        ControlsScene.SetActive(false);
        GameplayPopup.SetActive(true);
    }
    
}
