using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Manager : MonoBehaviour
{
    public GameObject Door_1;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Door_1.SetActive(false);
        }
    }
}
