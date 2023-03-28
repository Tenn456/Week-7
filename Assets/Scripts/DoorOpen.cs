using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    PlayerControl playerScript;

    // Start is called before the first frame update
    void Start()
    {
        //playerScript gets information from the PlayerControl script(component) on the Player game object
        playerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void OnMouseDown()
    {
        if(playerScript.hasKey == true)
        {
            //If player has key and clicks on door, it is destroyed
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
