using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpscript : MonoBehaviour
{

    public Transform TPtarget;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        Player.transform.position = TPtarget.transform.position;
    }
}
