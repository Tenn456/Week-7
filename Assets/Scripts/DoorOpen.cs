using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    PlayerControl playerScript;
    public string objectName;
    public bool doorCheck;

    // Start is called before the first frame update
    void Start()
    {
        //playerScript gets information from the PlayerControl script(component) on the Player game object
        playerScript = GameObject.Find("Player").GetComponent<PlayerControl>();

        //sets doorCheck bool to false
        doorCheck = false;
    }

    void OnMouseOver()
    {
        //When mouse is over key, displays itemName string on the console and replaces the itemText text to the itemName string
        Debug.Log(objectName);
        playerScript.itemText.text = objectName;
    }

    void OnMouseExit()
    {
        //When mouse moves away from key, displays lookingAt string on the console and replaces itemText text to the lookingAt string
        Debug.Log(playerScript.lookingAt);
        playerScript.itemText.text = playerScript.lookingAt;
    }

    void OnMouseDown()
    {
        if(playerScript.hasKey && playerScript.canBeCollected)
        {
            //If player has key and canBeCollected is true and clicks on door, doorCheck bool is set to true
            doorCheck = true;
        }
    }

    void Update()
    {
        if(doorCheck)
        {
            //If doorCheck is true, the console displays and itemText string change to the lookingAt string and the door is destroyed.
            Debug.Log(playerScript.lookingAt);
            playerScript.itemText.text = playerScript.lookingAt;
            playerScript.hasKey = false;
            Destroy(gameObject);
        }
    }
}
