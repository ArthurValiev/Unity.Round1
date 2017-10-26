using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannonBall : MonoBehaviour
{

    public GameObject ball;
    public Transform cannonEnd;

    public float force = 300;

    public float timer = 0; public float someThreshold = 2;

    void ShootBall()
    {
        GameObject ballInstance;

	    ballInstance = Instantiate(ball, cannonEnd.position, cannonEnd.rotation);
	    ballInstance.GetComponent<Rigidbody>().AddForce(cannonEnd.forward * force);
    }

    /*FixedUpdate: FixedUpdate is often called more frequently than Update.It can be called multiple times per frame, 
    if the frame rate is low and it may not be called between frames at all if the frame rate is high.
    All physics calculations and updates occur immediately after FixedUpdate.When applying movement 
    calculations inside FixedUpdate, you do not need to multiply your values by Time.deltaTime.
    This is because FixedUpdate is called on a reliable timer, independent of the frame rate.*/

	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBall();
        }

        //timer += Time.deltaTime;

        timer += Time.smoothDeltaTime;

		if (timer > someThreshold)
		{
            ShootBall();
			timer = 0;
		}


	}
}
