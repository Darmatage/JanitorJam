using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    //need to create Game Handler script
    //public GameHandlerScript gameHandler;
    public int carryCapacity = 1;
    //public int currentLoad; //don't need? or need so we can adjust speed if a player has an object or not
    public Transform pickupSlot1;
    //public Transform pickupSlot2;
    //public Transform pickupSlot3;
    private GameObject slot1Pickup;
    //private GameObject slot2Pickup;
    //private GameObject slot3Pickup;
    private GameObject CurrentPickup;
    private bool slot1isOpen = true;
    //private bool slot2isOpen = true;
    //private bool slot3isOpen = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            CurrentPickup = other.gameObject;
            PickUpThing();
        }
        if (other.gameObject.tag == "HomeBase") //this is for putting back in storage
        {
            PutDownThing();
        }
    }

    public void PickUpThing()
    {
        int availCapacity = carryCapacity; //- currentLoad;
        //int objWeightTemp = CurrentPickup.GetComponent().objWeight;
        if (availCapacity == 1) ///>= objWeightTemp)
        {
            if (slot1isOpen == true)
            {
                //currentLoad += objWeightTemp;
                CurrentPickup.transform.parent = pickupSlot1;
                CurrentPickup.transform.position = pickupSlot1.position;
                CurrentPickup.GetComponent<Rigidbody>().isKinematic = true;
                CurrentPickup.GetComponent<Collider>().enabled = false;
                slot1Pickup = CurrentPickup;
                slot1isOpen = false;
                //Debug.Log("slot 3 filled! \n current load weight = " + currentLoad);
            }
     //NOT using slot2 and slot 3 since we are only allowing one object to be picked up
            //else if (slot2isOpen == true)
            //{
            //    currentLoad += objWeightTemp;
            //    CurrentPickup.transform.parent = pickupSlot2;
            //    CurrentPickup.transform.position = pickupSlot2.position;
            //    CurrentPickup.GetComponent<Rigidbody>().isKinematic = true;
            //    CurrentPickup.GetComponent<Collider>().enabled = false;
            //    slot2Pickup = CurrentPickup;
            //    slot2isOpen = false;
            //    Debug.Log("slot 2 filled! \n current load weight = " + currentLoad);
            //}
            //else if (slot3isOpen == true)
            //{
            //    currentLoad += objWeightTemp;
            //    CurrentPickup.transform.parent = pickupSlot3;
            //    CurrentPickup.transform.position = pickupSlot3.position;
            //    CurrentPickup.GetComponent<Rigidbody>().isKinematic = true;
            //    CurrentPickup.GetComponent<Collider>().enabled = false;
            //    slot3Pickup = CurrentPickup;
            //    slot3isOpen = false;
            //    Debug.Log("slot 3 filled! \n current load weight = " + currentLoad);
            //}
        }
        //What do we put here??
        //else
        //{
        //    Debug.Log("Your load is too heavy to get that. \n Current weight: " + currentLoad);
        //}
    }


    public void PutDownThing()
    {
        //AGAIN, not using slot2 or slot3
        //if (slot3isOpen == false)
        //{
        //    Destroy(slot3Pickup.gameObject);
        //    slot3isOpen = true;
        //    Debug.Log("slot 3 emptied! \n curent load weight = " + currentLoad);
        //}
        //if (slot2isOpen == false)
        //{
        //    Destroy(slot2Pickup.gameObject);
        //    slot2isOpen = true;
        //    Debug.Log("slot 2 emptied! \n curent load weight = " + currentLoad);
        //}
        if (slot1isOpen == false)
        {
            //Uhhh I don't think we should be destroying it :/
            Destroy(slot1Pickup.gameObject);
            slot1isOpen = true;
            //Debug.Log("slot 1 emptied! \n curent load weight = " + currentLoad);
        }

        //gameHandler.GetComponent().updateScore(currentLoad);
        //currentLoad = 0;
        //Debug.Log("Curent load weight = " + currentLoad);
    }
}