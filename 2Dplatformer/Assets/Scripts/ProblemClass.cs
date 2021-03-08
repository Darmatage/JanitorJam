using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq; // ??? double check if this is needed


public class Problem : MonoBehaviour
{
    class problemEntity
    { 
        bool solvedByMop = true //??????
        // class constructor
        public problemEntity()
        {
            public string[] solveByArray = {
                "mop",
                "broom"
                // put more tools here};
        }

        
        // function to determine if the problem can be solved by a particular tool
        bool solvedBy(string tool)
        {
            if solvedByArray.Contains(tool)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        // create instance of class here???
    }

    // I think based on the timer, an instance of the problem class should be spawned somewhere on the map
    // maybe this code shouldn't go here and it should go in some kind of event handler. this code should just be about the problem behaviour. then create a prefab, then event
    // handler creates the prefabs around the map
    void Update()
    {
        
    }

    // this will be to resolve the problem
    void OnMouseDown() // or whatever key
    {
        if PROBLEMOBJECT.
        Destroy(gameObject);
    }
}
