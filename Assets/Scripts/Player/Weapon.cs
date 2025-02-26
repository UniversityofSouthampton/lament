using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // checks if tag is an enemy. add enemy tag to an enemy object
        Enemy_Whisper enemy = collision.gameObject.GetComponent<Enemy_Whisper>();
        if(enemy != null)
        {
            Debug.Log("Enemy has taken damage");
            enemy.TakeDamage(damage);
        } 

        if(collision.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<Enemy_Whisper>();
            Debug.Log("Enemy has taken damage!");
            enemy.TakeDamage(damage);
        }
    }
}

