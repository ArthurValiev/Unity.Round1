using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Transform target;

    public void Track(Transform t)
    {
        target = t;
    }

    public float speed = 0.1f;
    GameObject grabber;
    Vector3 originalLeverPos;
    Vector3 closestToGrabber;
    Vector3 localGrabberPos;

    void Start()
    {
        grabber = GameObject.Find("Grabber");
        originalLeverPos = transform.forward;
    }

    void Update()
    {
        
        DrawPlane(transform.position, transform.up.normalized);

        Debug.DrawRay(transform.position, originalLeverPos * 10, Color.blue);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.white);

        Debug.Log("ANGLE PIVOT   " + Vector3.Angle(originalLeverPos, transform.forward));
        Debug.Log("ANGLE GRABBER " + Vector3.Angle(originalLeverPos, grabber.transform.position - transform.position));

        if (target)
        {
            if (Vector3.Angle(originalLeverPos, grabber.transform.position - transform.position) < 45.0f)
            {
                localGrabberPos = transform.InverseTransformPoint(grabber.transform.position);
                localGrabberPos.y = 0;
                closestToGrabber = transform.TransformPoint(localGrabberPos);
                transform.LookAt(closestToGrabber, transform.up.normalized);
            }
			else
			{
				var rotation = Quaternion.LookRotation(originalLeverPos);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
			}
        }
		else
		{
			var rotation = Quaternion.LookRotation(originalLeverPos);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
		}
    }

    void DrawPlane(Vector3 position, Vector3 normal)
    {

        Vector3 v3;

        if (normal.normalized != Vector3.forward)
            v3 = Vector3.Cross(normal, Vector3.forward).normalized * normal.magnitude;
        else
            v3 = Vector3.Cross(normal, Vector3.up).normalized * normal.magnitude; ;

        var corner0 = position + v3;
        var corner2 = position - v3;
        var q = Quaternion.AngleAxis(90.0f, normal);
        v3 = q * v3;
        var corner1 = position + v3;
        var corner3 = position - v3;

        Debug.DrawLine(corner0, corner2, Color.green);
        Debug.DrawLine(corner1, corner3, Color.green);
        Debug.DrawLine(corner0, corner1, Color.green);
        Debug.DrawLine(corner1, corner2, Color.green);
        Debug.DrawLine(corner2, corner3, Color.green);
        Debug.DrawLine(corner3, corner0, Color.green);
        Debug.DrawRay(position, normal, Color.red);
    }

}