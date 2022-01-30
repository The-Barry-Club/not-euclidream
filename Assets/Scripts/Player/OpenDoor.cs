using System.Collections;
using System.Collections.Generic;
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
                Debug.Log("Instructions" + instructions);
                status = anim.GetBool("OpenClose");
                Debug.Log(status);
                anim.SetBool("OpenClose",!status);
                Debug.Log(anim.GetBool("OpenClose"));
            }
                
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Door")
            instructions.SetActive(false);
    }
}
