using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolPickup : MonoBehaviour
{

    private GameObject playerObject;
    private PlayerMovement player;
    private GameObject currTool;

    //private bool playerCanHave = true;

    private float distance;
    private float minimumDistance = 2f;

    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        //The commented out parts check if the player has a tool in their "hand" already

        distance = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distance <= minimumDistance)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                

                //if (!player.hasTool)
                //{
                    PickUpTool();
                    //Destroy(gameObject);
                //}

            }


        }
        else
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                //if (player.hasTool)
                //{
                    DropTool();
                //}


            }

        }

    }    
     void PickUpTool()
     {
        gameObject.SetActive(false);
        player.hasTool = true;
        player.tool = gameObject;
        currTool = gameObject;

     }

     void DropTool()
     {
            
        currTool.SetActive(true);
        player.tool = null;
        player.hasTool = false;
        currTool = null;
     }
    
}