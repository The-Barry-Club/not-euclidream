using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class Brightness : MonoBehaviour
{
    [Header("lights")] 
    public Light DirectionnalLight;
    //public Light Spot1;
    //public Light Spot2;
    //public Light Spot3;
    public Light Spot4;
    public Light Spot5;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int value = PlayerPrefs.GetInt("masterBrightness");
        DirectionnalLight.intensity = value;
        //Spot1.intensity = value;
        //Spot2.intensity = value;
        //Spot3.intensity = value;
        Spot4.intensity = value;
        Spot5.intensity = value;
    }
}
