using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    public int carryCapacity = 1;
    public Transform pickupSlot1;
    private GameObject slot1Pickup;
    private GameObject CurrentPickup;
    private bool slot1isOpen = true;



    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tool") && Input.GetKeyDown(KeyCode.Space))
        {
            CurrentPickup = other.gameObject;
            PickUpThing();
            //How do I make it so they grab the object but it doesn't go away
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "StorageRoom" && Input.GetKeyDown(KeyCode.Space))
        {
            PutDownThing();
        }

        //put if statement for if (other.gameObject.tag == "Problem") here
    }

    void PickUpThing()
    {
        int availCapacity = carryCapacity;
        if (availCapacity == 1)
        {
            if (slot1isOpen == true)
            {
                CurrentPickup.transform.parent = pickupSlot1;
                CurrentPickup.transform.position = pickupSlot1.position;
                CurrentPickup.GetComponent<Rigidbody>().isKinematic = true;
                CurrentPickup.GetComponent<Collider>().enabled = false;
                slot1Pickup = CurrentPickup;
                slot1isOpen = false;
            }
        }
    }

    void PutDownThing()
    {
        if (slot1isOpen == false)
        {
            slot1Pickup.gameObject.SetActive(true);
            slot1isOpen = true;
        }
    }
}
