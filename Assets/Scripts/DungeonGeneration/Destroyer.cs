﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("SpawnPoint") || other.CompareTag("closedRoom"))
		{
			Destroy(other.gameObject);
		}
	}
}