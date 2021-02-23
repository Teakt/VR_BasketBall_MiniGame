using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    [Header("[Score Management]")]
    [SerializeField] private Text score_text;
    [SerializeField] private Button reset_score_button;
    [SerializeField] private GameObject basket_checker; // object placed in basket checking if a ball marked or not 

    public int score_Player { get; set; } // the score is saved and modified here
   
    /*-----------------------------------------------------------------------------*/
   // public delegate void OnScoreChangeEvent(int score);
    //public event OnScoreChangeEvent OnScoreChange;

    // Start is called before the first frame update
    void Start()
    {
        score_Player = 0;
        score_text.text = "" + score_Player ;
    }

    // Update is called once per frame
    void Update()
    {
        score_text.text = "" + score_Player;
    }


    public int GetScore() //  et de même pour OnScoreChange avec le score. 
    {
        return score_Player;
    }

    public void SetScore(int score) //  et de même pour OnScoreChange avec le score. 
    {
        score_Player= score;
    }

    public void ResetScore()
    {
        score_Player = 0;
    }
}
