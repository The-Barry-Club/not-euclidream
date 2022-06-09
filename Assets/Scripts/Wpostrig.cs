using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wpostrig : MonoBehaviour
{
    public Camera cam;
    public RaymarchCam rcam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rcam = cam.GetComponent<RaymarchCam>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rcam._wPosition = 0;
            rcam.wpos.SetActive(false);
            rcam.waxe = false;
        }
    }
}
