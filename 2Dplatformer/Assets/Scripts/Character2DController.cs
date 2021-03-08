using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2DController : MonoBehaviour
{
    public float MovementSpeed = 2;
    private void Start()
    {
        
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        var movementVertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(0, movementVertical, 0) * Time.deltaTime * MovementSpeed;
    }
}
