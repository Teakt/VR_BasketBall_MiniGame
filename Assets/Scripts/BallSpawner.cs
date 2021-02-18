﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    

    
    

    [Header("[Ball Spawn Timers]")]
    [SerializeField]
    private float targetTime = 5.0f;
    [SerializeField]
    private float delay_spawn = 5.0f;
    [SerializeField]
    private int max_balls = 20; // maximum number of basketballs in the scene at the same time
    private int current_number_balls = 0 ; // number of balls initialized at 0 
    public GameObject ball_prefab;

    [Header("[Player Score Points]")]
    [SerializeField]
    private int maxScore = 20;
    [SerializeField]
    private int currentScore;


    [SerializeField]
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        

        if (targetTime <= 0.0f)
        {
            

            
            SpawnBall();
            targetTime = delay_spawn;
        }
        else
        {
            targetTime -= Time.deltaTime;
           
        }
        //Debug.Log(targetTime);
    }
    
    public void SpawnBall()
    {
        if(current_number_balls <= max_balls) //we check if we exceeded the number max of balls
        {
            GameObject prefab = Instantiate(ball_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            prefab.GetComponent<Rigidbody>().AddForce(Vector3.down);
            current_number_balls++; // we add a ball to the balls counter
        }
        
    }


    void OnTriggerExit(Collider ball)
    {
        // Destroy everything that leaves the trigger
        if (ball.gameObject.CompareTag("Ball"))
        {
            Destroy(ball.gameObject);
            current_number_balls--;
        }
        Debug.Log("BYE");
       
    }
}