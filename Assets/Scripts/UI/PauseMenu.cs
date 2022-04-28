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
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
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
    }
    
    public void MainMenuYesBtn()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("MainMenu");
        //SceneManager.LoadScene(_MainMenu);
    }

    public void MainMenuNoBtn()
    {
        MainMenuPopup.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    
    //SETTINGS BTN
    public void SettingsBtn()
    {
        pauseMenuUI.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void ExitSettings()
    {
        SettingsMenu.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    //QUIT BTN
    public void QuitBtn()
    {
        pauseMenuUI.SetActive(false);
        QuitPopup.SetActive(true);
    }
    public void Quit_YesBtn()
    {
        Application.Quit();
    }
    
    public void quitNoBtn()
    {
        QuitPopup.SetActive(false);
        pauseMenuUI.SetActive(true);
    }


}
