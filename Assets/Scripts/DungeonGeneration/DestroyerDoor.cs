using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerDoor : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
    {	
		if(other.CompareTag("Wall"))
		{
					Destroy(other.gameObject);
		}
		
	}
}
