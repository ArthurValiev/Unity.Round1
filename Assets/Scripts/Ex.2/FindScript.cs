using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FindScript : MonoBehaviour {


	public UnityEvent onPlayerVisible;
	public UnityEvent onPlayerInvisible;

    GameObject player;
    int layerMask = 1 << 9;

	void Start () {
        player = GameObject.Find("Player");
	}
	
    void Update () {
        Vector3 raycastDir = player.transform.position - transform.position;

        Ray landingRay = new Ray(transform.position, raycastDir);

        float x_diff = transform.position.x - player.transform.position.x;
        float z_diff = transform.position.z - player.transform.position.z;

        float distance = Mathf.Sqrt(Mathf.Pow(x_diff, 2) + Mathf.Pow(z_diff, 2));

        RaycastHit hit;

        if(Physics.Raycast(landingRay, out hit, distance, layerMask))
        {
            
            Debug.DrawRay(transform.position, raycastDir * hit.distance / distance, Color.white);
            //Debug.DrawLine(transform.position, hit.point, Color.white);

			onPlayerInvisible.Invoke();
            //Debug.Log("Hit" + hit.point);
            //Debug.Log("Ray " + raycastDir * hit.distance / distance);
        } 
        else
        {
			Debug.DrawRay(transform.position, raycastDir, Color.red);
            //Debug.DrawLine(transform.position, player.transform.position, Color.red);
            onPlayerVisible.Invoke();

        }
	}

}