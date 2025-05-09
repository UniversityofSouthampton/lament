using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WhisperProjectile : MonoBehaviour
{
    public float speed;
    public int damage = 1;

    private Transform player;
    private Vector2 target;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if(other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().TakeDamage(damage);
                DestroyProjectile();
            }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

}
