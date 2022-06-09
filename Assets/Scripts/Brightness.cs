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
   


    public Light[] lights;
    public float[] lightsOrigin;

    float oldValue = 0f;
    float value = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        lights = FindObjectsOfType<Light>();
        value =  PlayerPrefs.GetFloat("masterBrightness");
        lightsOrigin = new float[lights.Length];
        for(int i = 0; i< lights.Length;i++)
        {
            lightsOrigin[i] = lights[i].intensity;
        }

    }

    // Update is called once per frame
    void Update()
    {
        oldValue = value;
        value = PlayerPrefs.GetFloat("masterBrightness");
        for(int i = 0; i< lights.Length;i++)
        {
            if(oldValue != value)
                lights[i].intensity = lightsOrigin[i]*value;
        }
        
        
    }
}
