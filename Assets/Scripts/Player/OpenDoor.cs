using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Photon.Pun;

public class OpenDoor : MonoBehaviourPun
{
    public GameObject instructions;
    private bool status;

    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    { 
        if(view.IsMine){
        
            if(other.tag == "Door"){
                instructions.SetActive(true);
                Animator anim = other.GetComponentInChildren<Animator>();
                if(Input.GetKeyDown(KeyCode.E)){
                    PhotonView oview = other.GetComponentInChildren<PhotonView>();
                    oview.RequestOwnership();
                    status = anim.GetBool("OpenClose");
                    anim.SetBool("OpenClose",!status);
                }
                
            }    
        }
         
    }

    private void OnTriggerExit(Collider other)
    {
        if(view.IsMine && other.tag == "Door")
            instructions.SetActive(false);
    }
}
