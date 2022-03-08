using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 2f;

    public Transform playerBody;
<<<<<<< HEAD

    public Transform head;
    
    float xRotation = 0f;

    
    
=======
    float xRotation = 0f;

    
>>>>>>> main
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera rotation
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            xRotation -= mouseY;
<<<<<<< HEAD
            
            xRotation = Mathf.Clamp(xRotation, -68f, 68f);
            
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
            
            //Code to rotate the head
<<<<<<< HEAD
            float xRotationCopy = Mathf.Clamp(xRotation, -60f, 10f);
            head.transform.localRotation = Quaternion.Euler(xRotationCopy, 0f, 0f);
=======
            float xRotationCopy = Mathf.Clamp(xRotation, -50f, 10f);
            head.transform.localRotation = Quaternion.Euler(xRotationCopy-10, 0f, 0f);
>>>>>>> 9244777ca8b87c47efed7c20e09b158e645d6e1e
=======
            xRotation = Mathf.Clamp(xRotation, -68f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
>>>>>>> main
        

    }
}
