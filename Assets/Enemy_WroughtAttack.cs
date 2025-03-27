using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WroughtAttack : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Wrought hit player");
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
