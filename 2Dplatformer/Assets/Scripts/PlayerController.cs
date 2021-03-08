using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //How do I make it so they grab the object but it doesn't go away
            other.gameObject.SetActive(false);
        }
    }



}
