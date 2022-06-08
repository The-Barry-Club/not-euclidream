using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoose : MonoBehaviour
{
   
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<TptoBeginning>().Tp();
        }
    }
}
