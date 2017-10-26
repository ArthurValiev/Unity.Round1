using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    
	void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "ball")
        {
            //Destroy(other.gameObject);
            //Physics.gravity = new Vector3(0, 0, 10);

            gameObject.GetComponent<Renderer>().material.color = Color.magenta;

        }
	}
		
}