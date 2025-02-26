using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // checks if tag is an enemy. add enemy tag to an enemy object
        Enemy_Whisper enemy = collision.GetComponent<Enemy_Whisper>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
