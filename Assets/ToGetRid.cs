using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGetRid : MonoBehaviour
{

    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length>0)
           cam.SetActive(false); 
    }
}
