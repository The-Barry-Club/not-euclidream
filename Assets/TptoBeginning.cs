using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TptoBeginning : MonoBehaviour
{

    public GameObject tpLocation;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        tpLocation = GameObject.FindGameObjectsWithTag("DestinationTP")[0];
    }

    public void Tp(){
        audioSource.PlayOneShot(audioSource.clip, 1f);
        transform.position = tpLocation.GetComponent<Transform>().position;
    }
}
