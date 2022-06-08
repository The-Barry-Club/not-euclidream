using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjCollisions : MonoBehaviour
{
    public PlayerRayMarchCollider col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<PlayerRayMarchCollider>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Shape4D"))
            col.maxDownMovement = 0;
    }
}
