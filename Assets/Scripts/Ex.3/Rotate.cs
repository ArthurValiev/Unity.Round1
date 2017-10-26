using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    
    public float speed = 0.1f;
    GameObject leverBase;
    GameObject grabber;
    GameObject handle;
    float distance;
    Vector3 originalLeverPos;
    Vector3 closestToGrabber;
    Vector3 localGrabberPos;

    void Start()
    {
		leverBase = GameObject.Find("LeverBase");
		grabber = GameObject.Find("Grabber");
        handle = GameObject.Find("Handle");

        originalLeverPos = transform.forward;

    }

    void FixedUpdate()
    {
        
        distance = Vector3.Distance(handle.transform.position, grabber.transform.position);
        distance = distance - grabber.GetComponent<Grabber>().grabRange - 0.25f;


        //Debug.Log(Vector3.Angle(originalLeverPos, grabber.transform.position - transform.position));
        Debug.Log("FORWARD " + transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.white);

        Debug.Log("OrigGrabber " + Vector3.Angle(originalLeverPos, grabber.transform.position));
        Debug.Log("OrigTransFor " + Vector3.Angle(originalLeverPos,transform.forward));
        Debug.Log("Orig Grabber-Trans " + Vector3.Angle(originalLeverPos, grabber.transform.position - transform.position));

        if (Vector3.Angle(originalLeverPos, transform.forward) < 45.0f)
        {
            localGrabberPos = leverBase.transform.InverseTransformPoint(grabber.transform.position);
            localGrabberPos.y = 0;
			closestToGrabber = leverBase.transform.TransformPoint(localGrabberPos);
			//grabber.transform.position - transform.position

            transform.rotation = Quaternion.LookRotation(closestToGrabber, Vector3.up);
            //transform.LookAt(closestToGrabber);

        }
        else
        {
            var rotation = Quaternion.LookRotation(originalLeverPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
            //transform.rotation = Quaternion.LookRotation(originalLeverPos);
        }

	}
}
