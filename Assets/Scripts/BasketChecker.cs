﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketChecker : MonoBehaviour
{


    [SerializeField] private ScoreManager score_manager;

    [Header("[Timers]")]
    [SerializeField]
    private float countdownTime = 2.0f;
    [SerializeField]
    private float countdown;
    bool count = false;
    GameObject temp;
    protected void Awake()
    {

        countdown = countdownTime;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (count)
        {
            countdown -= Time.deltaTime;
        }
        if (countdown <= 0.0f)
        {

            temp.GetComponent<Ball>().Respawn();
            count = false;
            countdown = countdownTime;

        }

    }

    private void OnTriggerEnter(Collider ball)
    {
        if (ball.gameObject.CompareTag("Ball"))
        {
            temp = ball.gameObject;

            score_manager.SetScore(score_manager.GetScore() + 1);
            // reset ball scrip which send the ball to its initial position
            //deactivate the ball 
            count = true;
            

        }
    }

}
