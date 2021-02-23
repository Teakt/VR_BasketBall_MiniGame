using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Ball : MonoBehaviour
{
    [Header("[Ball Position Related Variables]")]
    [SerializeField]
    private Vector3 initial_position ;

    [Header("[Timers related to the ball respawning]")]
    [SerializeField]
    private float countdown_time = 3.0f;
    [SerializeField]
    private float countdown ;
    bool count = false;

    [Header("[Variables related to the double checker]")]
    [SerializeField]
    private bool checked_top ;
    [SerializeField]
    private bool checked_bot;
    


    [SerializeField] private ScoreManager score_manager;


    [SerializeField] private VRTK_InteractableObject interact_object;

    void Awake() // We save the initial position of the ball when its spawned 
    {
        score_manager = FindObjectOfType<ScoreManager>();
        initial_position = this.transform.position;

        // We initalize the countdown
        countdown = countdown_time;
        checked_top = false;
        checked_bot = false;

        interact_object = GetComponent<VRTK_InteractableObject>();
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

            Respawn();
  
        }
        //we check if the double chek for the rim condition is fulfilled
        

        
    }

    public void Respawn()
    {
        // Deactivate the gameObject then   respawn / activate it again at thez initial pos 
        // We also cancel all the applied physics applied to the ball previous to the respawning
        this.gameObject.SetActive(false);
        this.transform.position = initial_position;
        countdown = countdown_time;
        count = false;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero; // reset physics
        checked_top = false; //resets the checkers
        checked_bot = false;
        this.gameObject.SetActive(true);
    }

    // We have to manage the ball when it hits the ground , it waits a bit then disapear
    void OnCollisionEnter(Collision ball)
    {
        // Destroy everything that leaves the trigger
        if (ball.gameObject.CompareTag("ExcludeTeleport"))
        {
            count = true;
           
        }
        
    }

    private void OnTriggerEnter(Collider checker)
    {
        if (!interact_object.IsGrabbed())
        {
            if (checker.gameObject.CompareTag("Checker1")) // check if the ball enters the rim
            {

                checked_top = true;

            }
            if (checker.gameObject.CompareTag("Checker2") && checked_top) // check if the ball enters the net after entering the top
            {

                //checked_bot = true;

                score_manager.SetScore(score_manager.GetScore() + 1);
            }
        }
        
       
       
    }
}
