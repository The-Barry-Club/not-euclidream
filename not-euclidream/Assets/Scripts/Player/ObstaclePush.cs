using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    public float forceMagnitude;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null)
        {
            Vector3 ForceDirection = hit.gameObject.transform.position - transform.position;
            ForceDirection.y = 0;
            ForceDirection.Normalize();

            rb.AddForceAtPosition(ForceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
