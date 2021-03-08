using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timeRemaining = 8; //8 minutes = 8 hours
    public bool timerIsRunning = false;
    public Text timeText;

    // Problems
    public GameObject problem;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;

        // Spawn problems
        InvokeRepeating("SpawnProblems", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time's Up!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

       
    }

    void DisplayTime(float timeToDisplay)
    {
        /*this makes it so that when you count down and have < base second, 
          the base second will stil display.
          In other words, when you have less than one second left, but MORE 
          than 0 seconds left, the dislpay will be "1" instead of "0" */
        timeToDisplay += 1;

        //calculating the number to display in minutes and seconds. 
        //I was thinking the game timer could have minutes correspond to hours (8 min = 8hrs)
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    void SpawnProblems()
    {
        GameObject instance = Instantiate(problem, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
