using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    private bool isGrounded;

    //For multiplayer
    private PhotonView view;
    public GameObject playerCamera;

    private void Start()
    {
        //For multiplayer
        view = GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //For multiplayer
        if (view.IsMine)
        {
            if(playerCamera.activeInHierarchy == false)
                playerCamera.SetActive(true);
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (move.magnitude > 1) 
                move /= move.magnitude;

            controller.Move(move * speed * Time.deltaTime);

            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        }
}
