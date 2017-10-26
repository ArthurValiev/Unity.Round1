using UnityEngine;
using System.Collections;

public class DestroyBall : MonoBehaviour
{

	void OnCollisionExit(Collision col)
	{
        if (col.gameObject.name == "Plane")
        {
            Destroy(gameObject);
        }		
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}