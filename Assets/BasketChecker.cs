using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketChecker : MonoBehaviour
{


    [SerializeField] private ScoreManager score_manager;

    protected  void Awake()
    {
        
        

      

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider ball)
    {
        if (ball.gameObject.CompareTag("Ball"))
        {
            score_manager.SetScore(score_manager.GetScore() + 1);
        }
    }

}
