using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    //THE MENU
    //[Header("Levels To Load")]
    //public string _MainMenu;

    [Header("PauseMenu")] 
    public GameObject pauseMenuUI;
    public GameObject MainMenuPopup;
    public GameObject QuitPopup;
    public GameObject SettingsMenu;

    //UPDATE
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                int scine = PlayerPrefs.GetInt("sceneloaded");
                if (scine == 0)
                {
                    ResumeGame();
                }
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerPrefs.SetInt("sceneloaded", -1);
    }

    void Pause()
    {
        PlayerPrefs.SetInt("sceneloaded", 0);
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //MAIN MENU BTN
    public void MainMenuBtn()
    {
        pauseMenuUI.SetActive(false);
        MainMenuPopup.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 20);
    }
    
    public void MainMenuYesBtn()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("MainMenu");
        PlayerPrefs.SetInt("sceneloaded", -1);
        //SceneManager.LoadScene(_MainMenu);
    }

    public void MainMenuNoBtn()
    {
        MainMenuPopup.SetActive(false);
        pauseMenuUI.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 0);
    }
    
    //SETTINGS BTN
    public void SettingsBtn()
    {
        pauseMenuUI.SetActive(false);
        SettingsMenu.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 1);
    }

    public void ExitSettings()
    {
        SettingsMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 0);
    }

    //QUIT BTN
    public void QuitBtn()
    {
        pauseMenuUI.SetActive(false);
        QuitPopup.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 22);
    }
    public void Quit_YesBtn()
    {
        PlayerPrefs.SetInt("sceneloaded", -1);
        Application.Quit();
    }
    
    public void quitNoBtn()
    {
        QuitPopup.SetActive(false);
        pauseMenuUI.SetActive(true);
        PlayerPrefs.SetInt("sceneloaded", 0);
    }


}
