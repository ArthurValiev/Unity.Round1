using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour {

	GameObject cube1;
	GameObject cube2;

	// Use this for initialization
	void Start () {

		cube1 = GameObject.Find("Cube_1");
		cube2 = GameObject.Find("Cube_2");

        Debug.Log("Начальная позиция cube1 " + cube1.transform.position);
        Debug.Log("Начальная позиция cube2 " + cube2.transform.position);




	}
	
	// Update is called once per frame
	void Update () {
        
		Vector3 localcube1Pos = cube2.transform.InverseTransformPoint(cube1.transform.position);

		Debug.Log("Новая позиция cube1 " + localcube1Pos);
	}
}
