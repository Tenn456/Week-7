using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public string itemName;
    public int itemValue;
    PlayerControl playerScript;
    AudioSource ding;
    public bool collected;
    

    // Start is called before the first frame update
    void Start()
    {
        //playerScript gets information from the PlayerControl script(component) on the Player game object
        playerScript = GameObject.Find("Player").GetComponent<PlayerControl>();
        ding = GameObject.Find("Player").GetComponent<AudioSource>();
        
        //Sets bool collected to false
        collected = false;
    }

    void OnMouseOver()
    {
        //When mouse is over key, displays itemName string on the console and replaces the itemText text to the itemName string
        Debug.Log(itemName);
        playerScript.itemText.text = itemName;
    }

    void OnMouseExit()
    {
        //When mouse moves away from key, displays lookingAt string on the console and replaces itemText text to the lookingAt string
        Debug.Log(playerScript.lookingAt);
        playerScript.itemText.text = playerScript.lookingAt;
    }

    void OnMouseDown()
    {
        //When mouse clicks on key, if canBeCollected is true, sets bool hasKey from playerScript to true and sets bool collected to true
        if(playerScript.canBeCollected)
        {
            playerScript.hasKey = true;
            collected = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collected)
        {
            //if bool collected is true, displays lookingAt string on the console, replaces itemText text to the lookingAt string, collected is set to false and destroys game object
            Debug.Log(playerScript.lookingAt);
            playerScript.itemText.text = playerScript.lookingAt;
            ding.Play();
            Destroy(gameObject);
        }
    }
}
