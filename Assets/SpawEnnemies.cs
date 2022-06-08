using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawEnnemies : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log("ennemies : "+players.Length);
        if(players.Length == 0)
        {
            PhotonNetwork.Instantiate("Ennemy", new Vector3(-217f,0.51f,-73f), Quaternion.identity);
        PhotonNetwork.Instantiate("Ennemy", new Vector3(-217f,0.51f,-35f), Quaternion.identity);
        PhotonNetwork.Instantiate("Ennemy", new Vector3(-238f,0.51f,-35f), Quaternion.identity);
        PhotonNetwork.Instantiate("Ennemy", new Vector3(-262f,0.51f,-48f), Quaternion.identity);
        PhotonNetwork.Instantiate("Ennemy", new Vector3(-273f,0.51f,-75f), Quaternion.identity);
        PhotonNetwork.Instantiate("Ennemy", new Vector3(-248f,0.51f,-63f), Quaternion.identity);
    }
        }
        

}
