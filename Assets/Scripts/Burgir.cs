using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burgir : MonoBehaviour
{
    public GameObject burgir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 3.2f)
            burgir.SetActive(true);
        else
            burgir.SetActive(false);
    }
}
