using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr4Dpopup : MonoBehaviour
{
    public GameObject instructions;
    // Start is called before the first frame update
    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Button")
        {
            instructions.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button")
        {
            instructions.SetActive(false);
        }
    }
}
