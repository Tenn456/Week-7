using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public float speed;

    public float upRotation;
    public float downRotation;

    CharacterController characterControl;

    public Transform playerCam;

    Vector3 vel;

    public float lookSensitivity;

    float xRotation = 0;

    public TMP_Text itemText;
    public string lookingAt = "nothing!";

    public bool hasKey = false;

    public KeyCode runButton;
    public KeyCode jumpButton;

    public float castDist;
    public float floorDist;

    public Camera mainCam;

    public bool jump;
    public bool canBeCollected;

    
    public float gravity = -9.81f;
    public float gravityScale = 1;
    public float jumpHeight = 4;
    float velocity;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //Locks the Cursor
        Cursor.lockState = CursorLockMode.Locked;
        //characterControl gets information from the CharacterController component
        characterControl = GetComponent<CharacterController>();
        
        

        //Setting the itemText text to the lookingAt string
        itemText.text = lookingAt;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Movement
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        //Tracks camera movement
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        //Restricts range of the camera
        xRotation = Mathf.Clamp(xRotation, -upRotation, downRotation);
        //Links camera movement to player
        playerCam.localRotation = Quaternion.Euler(xRotation, 0, 0);

        //Tracks Player Movement
        vel.z = Input.GetAxis("Vertical") * speed;
        vel.x = Input.GetAxis("Horizontal") * speed;

        //Makes the player move based on where they are facing
        vel = transform.TransformDirection(vel);
        //Makes the player move
        characterControl.SimpleMove(vel);

        //if the player holds the run button, the player's speed is tripled
        if(Input.GetKeyDown(runButton))
        {
            speed *= 3;
        }

        //if the player releases the run button, the player's speed is divided by 3;
        if(Input.GetKeyUp(runButton))
        {
            speed /= 3;
        }

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        RaycastHit floor;
        Vector3 rayStart = mainCam.ViewportToWorldPoint(Input.mousePosition);

        //If the player is close enough to a Game Object, canBeCollected will be true
        if(Physics.Raycast(rayStart, playerCam.forward, out hit, castDist))
        {
            canBeCollected = true;
        }
        
        //else it will be false
        else
        {
            canBeCollected = false;
        }

        //If the player is on the ground, jump will be true
        if(Physics.Raycast(rayStart, -playerCam.up, out floor, floorDist))
        {
            jump = true;
        }

        //else it will be false
        else
        {
            jump = false;
        }
        
        //if jump is true and the jump button is pressed, the player will jump
        if(jump && Input.GetKeyDown(jumpButton))
        {
            Debug.Log("Jump!");
            velocity = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
        }
        velocity += gravity * gravityScale * Time.deltaTime;
        MovePlayer();

        void MovePlayer()
        {
            characterControl.Move(new Vector3(0, velocity, 0) * Time.deltaTime);
        }
    }
}
