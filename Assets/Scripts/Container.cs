using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    // Start is called before the first frame update






    [Header("[Ball Spawn Timers]")]
    [SerializeField]
    private float targetTime = 5.0f;
    [SerializeField]
    private float delay_spawn = 5.0f;
    [SerializeField]
    private int max_balls = 5; // maximum number of basketballs in the scene at the same time
    private int current_number_balls = 0; // number of balls initialized at 0 
    public GameObject ball_prefab;




    

    // Update is called once per frame
    void FixedUpdate()
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
        if (current_number_balls < max_balls) //we check if we exceeded the number max of balls
        {
            GameObject prefab = Instantiate(ball_prefab, this.transform.position, Quaternion.identity); // at this object position allows the ball to be spawned at the same place in every prefab of the container
            //prefab.GetComponent<Rigidbody>().AddForce(Vector3.down);
            current_number_balls++; // we add a ball to the balls counter
        }

    }

  

}