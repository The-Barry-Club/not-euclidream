using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burgir : MonoBehaviour
{
    public GameObject burgir;
    public AudioSource au;
    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 3.2f)
        {
            au.Play();
            burgir.SetActive(true);
        }
        else
            burgir.SetActive(false);
    }
}
