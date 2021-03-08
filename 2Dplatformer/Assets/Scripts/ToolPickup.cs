using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickup : MonoBehaviour
{
    //public int carryCapacity = 1;
    //private GameObject CurrentPickup;
    private bool playerCanHave = false;
    PlayerMovement player = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!playerCanHave)
            {
                DropThing();
            }
            else
            {
                PickUpThing();
            }
            
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<PlayerMovement>();
        if (player != null && (!player.hasTool))
        {
            playerCanHave = true;

        }
        else
        {
            playerCanHave = false;
        }


        //put if statement for if (other.gameObject.tag == "Problem") here
    }

    void PickUpThing()
    {
        gameObject.SetActive(false);
        player.hasTool = true;
        player.tool = gameObject;
        playerCanHave = false;

    }

    void DropThing()
    {
        player.tool.SetActive(true);
        player.tool = null;
        player.hasTool = false;
    }
}
