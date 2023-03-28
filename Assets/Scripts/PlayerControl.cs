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
        characterControl.Move(vel * Time.deltaTime);
    }
}
