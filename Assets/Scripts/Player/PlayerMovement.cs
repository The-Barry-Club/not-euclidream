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
    
    //For animations
    public Animator animator;
    private int isWalkingHash;
<<<<<<< HEAD
    private int isWalkingBackwardsHash;
    private int isJumpingHash;
=======
>>>>>>> main

    private void Start()
    {
        //For multiplayer
        view = GetComponent<PhotonView>();
<<<<<<< HEAD
        
        //For animations
        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
        isJumpingHash = Animator.StringToHash("isWalkingBackwards");
=======
        Debug.Log(animator);
        
        //For animations
        isWalkingHash = Animator.StringToHash("isWalking");
<<<<<<< HEAD
<<<<<<< HEAD
        isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
        isJumpingHash = Animator.StringToHash("isWalkingBackwards");
=======
=======
>>>>>>> 9244777ca8b87c47efed7c20e09b158e645d6e1e
>>>>>>> main

    }

    // Update is called once per frame
    void Update()
    {
        
        //For multiplayer
        if (view.IsMine)
        {
            //For multiplayer
            if(playerCamera.activeInHierarchy == false)
                playerCamera.SetActive(true);
            
<<<<<<< HEAD
            
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            
            // ----- Animations --------

            bool isWalking = animator.GetBool(isWalkingHash);
            bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
            bool isJumping = animator.GetBool(isJumpingHash);
            bool forward = Input.GetKey("z");
            bool backward = Input.GetKey("s");
            bool jump = Input.GetKey("space");
=======
            // ----- Animations --------

            bool isWalking = animator.GetBool(isWalkingHash);
            bool forward = Input.GetKey("z");
>>>>>>> main
            if(!isWalking && forward)
                animator.SetBool(isWalkingHash,true);
            
            if(isWalking && !forward)
                animator.SetBool(isWalkingHash,false);
            
<<<<<<< HEAD
            if(!isWalkingBackwards && backward)
                animator.SetBool(isWalkingBackwardsHash,true);
            
            if(isWalkingBackwards && !backward)
                animator.SetBool(isWalkingBackwardsHash,false);
            
            if(!isJumping && isGrounded && jump)
                animator.SetBool(isJumpingHash,true);
            
            if(isJumping && isGrounded && !jump)
                animator.SetBool(isJumpingHash,false);
=======
            
>>>>>>> main
            
            
            
            // ----- End anims. --------
            
<<<<<<< HEAD
            
=======
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
>>>>>>> main

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
