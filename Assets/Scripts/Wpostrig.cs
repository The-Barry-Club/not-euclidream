using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wpostrig : MonoBehaviour
{
    public Camera cam;
    public RaymarchCam rcam;
    public GameObject cutcam;
    public GameObject timeline;
    public GameObject cat;
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
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            rcam._wPosition = 0;
            rcam.wpos.SetActive(false);
            rcam.waxe = false;
            cat.GetComponent<CatController>().enabled = false;
            cat.transform.position = new Vector3(-224.81893920898438f,1.6593523025512696f,-496.6573791503906f);
            cat.transform.rotation = new Quaternion(0, 0.922334552f, 0, 0.386392355f);
            cutcam.SetActive(true);
            timeline.SetActive(true);
            StartCoroutine(Fincut());

        }
    }

    IEnumerator Fincut()
    {
        yield return new WaitForSeconds(4);
        cutcam.SetActive(false);
        cat.GetComponent<CatController>().enabled = true;
        timeline.SetActive(false);
    }
}
