using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Whisper : MonoBehaviour
{
    public RoomManager roomManager;

    [Header("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBetweenShots;
    private float timeBetweenShots;

    [Header("References")]
    public GameObject projectile;
    private Transform player;

    [Header("Health")]
    public float maxHealth = 3f;
    public float currentHealth;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    void Update()
    {
        HandleMovement();
        HandleProjectile();
    }

    void HandleMovement()
    {
        if(Vector2.Distance(transform.position, player.position) < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance)
        {
            transform.position = this.transform.position;
        }
    }

    void HandleProjectile()
    {
        if(timeBetweenShots <= 0 && (Vector2.Distance(transform.position, player.position) > nearDistance))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            roomManager.EnemyKilled(gameObject);
            Destroy(gameObject);
        }
    }
}
