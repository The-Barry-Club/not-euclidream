using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class sensiMaster : MonoBehaviour
{

    public GameObject[] players;
    

    float oldValue = 0f;
    float value = 0f;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       foreach(GameObject pla in players)
       {
           oldValue = value;
           value = PlayerPrefs.GetFloat("masterSensi");
           if(oldValue != value && pla.GetComponent<PhotonView>().IsMine) pla.GetComponentInChildren<CameraController>().mouseSensitivity = value;

       } 
    }
}
