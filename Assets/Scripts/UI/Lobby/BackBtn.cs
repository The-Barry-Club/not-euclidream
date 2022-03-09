using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BackBtn : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _ExitGame;

    public void ExitBtn()
    {
        SceneManager.LoadScene(_ExitGame);
    }

}
