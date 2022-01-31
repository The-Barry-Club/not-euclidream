using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject instructions;
    private bool status;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Door"){
            instructions.SetActive(true);
            Animator anim = other.GetComponentInChildren<Animator>();
            if(Input.GetKeyDown(KeyCode.E)){
                status = anim.GetBool("OpenClose");
                anim.SetBool("OpenClose",!status);
            }
                
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Door")
            instructions.SetActive(false);
    }
}
