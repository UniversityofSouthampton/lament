using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       //Logic for Whisper enemy

        Enemy_Whisper enemy = collision.gameObject.GetComponent<Enemy_Whisper>();
        Enemy_Wrought enemyWrought = collision.gameObject.GetComponent<Enemy_Wrought>();
        
        
        
        if(enemy != null)
        {
            Debug.Log("Enemy  has taken damage");
            enemy.TakeDamage(damage);
        } 

        if(enemyWrought != null)
        {
            Debug.Log("Enemy  has taken damage");
            enemyWrought.TakeDamage(damage);
        }

        if(collision.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<Enemy_Whisper>();
            enemyWrought = collision.gameObject.GetComponent<Enemy_Wrought>();
            Debug.Log("Enemy  has taken damage!");
            enemy.TakeDamage(damage);
            enemyWrought.TakeDamage(damage);
        }
    }
}

