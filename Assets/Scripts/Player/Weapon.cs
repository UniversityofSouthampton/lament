using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1;

    public float damageBoost;

    void Update()
    {
        damageBoost = PlayerStatsManager.Instance.damageBoost;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       //Logic for Whisper enemy

        Enemy_Whisper enemy = collision.gameObject.GetComponent<Enemy_Whisper>();
        Enemy_Wrought enemyWrought = collision.gameObject.GetComponent<Enemy_Wrought>();


        if(collision.CompareTag("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<Enemy_Whisper>();
            enemyWrought = collision.gameObject.GetComponent<Enemy_Wrought>();
            //Debug.Log("Enemy  has taken damage!");
           
            if (enemy is not null)
            {
                enemy.TakeDamage(damage + damageBoost);
            }
            
            if (enemyWrought is not null)
            {
                enemyWrought.TakeDamage(damage + damageBoost);
            }
            
        }
    }
}

