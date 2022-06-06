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
    public bool isGrounded;
    public bool isGrounded4d;
    public static bool IsGrounded4d { set; get; }

    //For multiplayer
    private PhotonView view;
    public GameObject playerCamera;
    
    //For animations
    public Animator animator;
    private int isWalkingHash;
    private int isWalkingBackwardsHash;
    private int isJumpingHash;

    //List of keys
    public List<KeyCode> keez = new List<KeyCode>();
    public KeyCode Up = KeyCode.None;
    public KeyCode Down = KeyCode.None;
    public KeyCode Right = KeyCode.None;
    public KeyCode Left = KeyCode.None;
    public KeyCode Jump = KeyCode.None;
    public KeyCode Interact = KeyCode.None;


    private void Start()
    {
        //For multiplayer
        view = GetComponent<PhotonView>();
        
        //For animations
        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
        isJumpingHash = Animator.StringToHash("isWalkingBackwards");
        
        //Fill the list of keys
        foreach (KeyCode k in System.Enum.GetValues(typeof(KeyCode)))
        {
            keez.Add(k);
        }

        Up = keez[PlayerPrefs.GetInt("Up")];
        Down = keez[PlayerPrefs.GetInt("Down")];
        Right = keez[PlayerPrefs.GetInt("Right")];
        Left = keez[PlayerPrefs.GetInt("Left")];
        Jump = keez[PlayerPrefs.GetInt("Jump")];
        Interact = keez[PlayerPrefs.GetInt("Interact")];

    }

    // Update is called once per frame
    void Update()
    {
        //Update Keys
        Up = keez[PlayerPrefs.GetInt("Up")];
        Down = keez[PlayerPrefs.GetInt("Down")];
        Right = keez[PlayerPrefs.GetInt("Right")];
        Left = keez[PlayerPrefs.GetInt("Left")];
        Jump = keez[PlayerPrefs.GetInt("Jump")];
        Interact = keez[PlayerPrefs.GetInt("Interact")];
        
        //For multiplayer
        if (view.IsMine)
        {
            //For multiplayer
            if(playerCamera.activeInHierarchy == false)
                playerCamera.SetActive(true);
            
            
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            
            //Keys
            
            
            // ----- Animations --------

            bool isWalking = animator.GetBool(isWalkingHash);
            bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
            bool isJumping = animator.GetBool(isJumpingHash);
            bool forward = Input.GetKey(Up);
            bool backward = Input.GetKey(Down);
            bool jump = Input.GetKey(Jump);
            if(!isWalking && forward)
                animator.SetBool(isWalkingHash,true);
            
            if(isWalking && !forward)
                animator.SetBool(isWalkingHash,false);
            
            if(!isWalkingBackwards && backward)
                animator.SetBool(isWalkingBackwardsHash,true);
            
            if(isWalkingBackwards && !backward)
                animator.SetBool(isWalkingBackwardsHash,false);
            
            if(!isJumping && isGrounded && jump)
                animator.SetBool(isJumpingHash,true);
            
            if(isJumping && isGrounded && !jump)
                animator.SetBool(isJumpingHash,false);
            
            
            
            // ----- End anims. --------
            
            

            if((isGrounded || isGrounded4d) && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (move.magnitude > 1) 
                move /= move.magnitude;

            controller.Move(move * speed * Time.deltaTime);

            if(Input.GetButtonDown("Jump") && (isGrounded || isGrounded4d))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            if (!isGrounded4d && !isGrounded)
                velocity.y += gravity * Time.deltaTime;
            Debug.Log(velocity.y);
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
