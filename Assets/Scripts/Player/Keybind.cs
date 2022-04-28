using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Keybind : MonoBehaviour
{
    [Header("Popups")]
    public GameObject ControlsScene;
    public GameObject WaitPopup;
    
    
    [Header("Values Text")]
    [SerializeField] private TMP_Text Up = null;
    [SerializeField] private TMP_Text Down = null;
    [SerializeField] private TMP_Text Right = null;
    [SerializeField] private TMP_Text Left = null;
    [SerializeField] private TMP_Text Jump = null;
    [SerializeField] private TMP_Text Interact = null; 
    
    
    //LISTE QUI VA CONTENIR LES KEYS
    public List<KeyCode> keez = new List<KeyCode>();

    //LISTE DES KEYS
    void Start()
    {
        foreach (KeyCode k in System.Enum.GetValues(typeof(KeyCode)))
        {
            keez.Add(k);
        }

        //BASE KEYS
        PlayerPrefs.SetInt("Up", 71);
        PlayerPrefs.SetInt("Down", 64);
        PlayerPrefs.SetInt("Right", 49);
        PlayerPrefs.SetInt("Left", 62);
        PlayerPrefs.SetInt("Jump", 7);
        PlayerPrefs.SetInt("Interact", 50);
    }

    //UP
    public void InputUp()
    {
        ControlsScene.SetActive(false);
        WaitPopup.SetActive(true);
        bool notyetup = true;
        while (notyetup)
        {for (int i = 0; i < keez.Count; i++)
        {
            if (Input.GetKey(keez[i]))
            {
                PlayerPrefs.SetInt("Up", i);
                notyetup = false;
                break;
            }
        }}
        WaitPopup.SetActive(false);
        ControlsScene.SetActive(true);
    }
    
    //DOWN
    public void InputDown()
    {
        ControlsScene.SetActive(false);
        WaitPopup.SetActive(true);
        bool notyetdown = true;
        while (notyetdown)
        {for (int i = 0; i < keez.Count; i++)
        {
            if (Input.GetKey(keez[i]))
            {
                PlayerPrefs.SetInt("Down", i);
                notyetdown = false;
                break;
            }
        }}
        WaitPopup.SetActive(false);
        ControlsScene.SetActive(true);
    }
    
    //RIGHT
    private void GetInputRight()
    {
        bool answer = true;
        for (int i = 0; i < keez.Count; i++) 
        { 
            if (Input.GetKey(keez[i])) 
            { 
                PlayerPrefs.SetInt("Right", i);
                answer = false;
                break; 
            } 
        }

        if (answer)
        {
            GetInputRight();
        };
    }
    
    public void InputRight()
    {
        ControlsScene.SetActive(false);
        WaitPopup.SetActive(true);

        GetInputRight();
        
        WaitPopup.SetActive(false);
        ControlsScene.SetActive(true);
    }

    //LEFT
    public void InputLeft()
    {
        ControlsScene.SetActive(false);
        WaitPopup.SetActive(true);
        bool notyetleft = true;
        while (notyetleft)
        {for (int i = 0; i < keez.Count; i++)
        {
            if (Input.GetKey(keez[i]))
            {
                PlayerPrefs.SetInt("Left", i);
                notyetleft = false;
                break;
            }
        }}
        WaitPopup.SetActive(false);
        ControlsScene.SetActive(true);
    }

    //JUMP
    public void InputJump()
    {
        ControlsScene.SetActive(false);
        WaitPopup.SetActive(true);
        bool notyetjump = true;
        while (notyetjump)
        {for (int i = 0; i < keez.Count; i++)
        {
            if (Input.GetKey(keez[i]))
            {
                PlayerPrefs.SetInt("Jump", i);
                notyetjump = false;
                break;
            }
        }}
        WaitPopup.SetActive(false);
        ControlsScene.SetActive(true);
    }
    
    //Interact
    public void InputInteract()
    {
        ControlsScene.SetActive(false);
        WaitPopup.SetActive(true);
        bool notyetinteract = true;
        while (notyetinteract)
        {for (int i = 0; i < keez.Count; i++)
        {
            if (Input.GetKey(keez[i]))
            {
                PlayerPrefs.SetInt("Interact", i);
                notyetinteract = false;
                break;
            }
        }}
        WaitPopup.SetActive(false);
        ControlsScene.SetActive(true);
    }
    
    void Update()
    {
        Up.text = keez[PlayerPrefs.GetInt("Up")].ToString();
        Down.text = keez[PlayerPrefs.GetInt("Down")].ToString();
        Right.text = keez[PlayerPrefs.GetInt("Right")].ToString();
        Left.text = keez[PlayerPrefs.GetInt("Left")].ToString();
        Jump.text = keez[PlayerPrefs.GetInt("Jump")].ToString();
        Interact.text = keez[PlayerPrefs.GetInt("Interact")].ToString();
    }
}
