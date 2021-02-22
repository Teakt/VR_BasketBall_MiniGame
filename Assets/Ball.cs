using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake() // We save the initial position of the ball when its spawned 
    {
        initial_position = this.transform.position;

        // We initalize the countdown
        countdown = countdown_time; 
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
    }

    public void Respawn()
    {
        // Deactivate the gameObject then   respawn / activate it again at thez initial pos 
        // We also cancel all the applied physics applied to the ball previous to the respawning
        this.gameObject.SetActive(false);
        this.transform.position = initial_position;
        countdown = countdown_time;
        count = false;
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
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
}
