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
        InvokeRepeating("SpawnProblems", 2.0f, 10.0f);
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
        float spawn_x;
        float spawn_y;

        float[,] room_ranges = new float[,]
        {
            { -8.7f, 3.5f, -3.7f, 0.0f },
            { -0.5f, 4.0f, 1.6f, 1.15f },
            { 4.7f, 4.0f, 9.0f, 1.0f },
            { -9.3f, -3.3f, -3.4f, -4.0f },
            { -0.4f, -2.0f, 3.0f, -4.2f },
            { 5.8f, -1.7f, 9.3f, -4.1f }
        };

        int room_index = Random.Range(0, 6);
        spawn_x = Random.Range( room_ranges[room_index, 0], room_ranges[room_index, 2] );
        spawn_y = Random.Range(room_ranges[room_index, 1], room_ranges[room_index, 3]);

        // Need to make more prefabs of different problem types then randomly choose one 
        GameObject problemInstance = Instantiate(problem, new Vector3(spawn_x, spawn_y, 0), Quaternion.identity);
        problemInstance.GetComponent<ProblemScript>().solvedByMop = true;
        problemInstance.GetComponent<ProblemScript>().solvedByBroom = true;
    }
}
