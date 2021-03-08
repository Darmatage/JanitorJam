using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemScript : MonoBehaviour
{
    public bool solvedByMop = false;
    public bool solvedByBroom = false;

    public class problem
    {
        public bool solvedByMop;
        public bool solvedByBroom;

        public problem(bool mop, bool broom)
        {
            solvedByMop = mop;
            solvedByBroom = broom;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        problem problemInstance = new problem(solvedByMop, solvedByBroom);
    }

    // Update is called once per frame
    void Update()
    {
    }
}


