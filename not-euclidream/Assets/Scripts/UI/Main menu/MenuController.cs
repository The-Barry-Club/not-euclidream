using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
}