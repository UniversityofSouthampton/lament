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

    Animator anim;
    private Rigidbody2D rb2d;
    private float velocityX;
    private float velocityY;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    

    void Update()
    {
        HandleMovement();
        HandleProjectile();
        Animate();
        
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
        
        // Get the movement direction and calculate the velocity based on the movement
        Vector2 movement = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime) - (Vector2)transform.position;

        // Store the velocity values in X and Y
        velocityX = movement.x / Time.deltaTime;
        velocityY = movement.y / Time.deltaTime;
    }

    void HandleProjectile()
    {
        if(timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
            anim.SetTrigger("isAttacking");
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("isHurt");
        if(currentHealth <= 0)
        {
            roomManager.EnemyKilled(gameObject);
            Destroy(gameObject);
        }
    }
    
    void Animate()
    {
        anim.SetFloat("MoveX", velocityX);
        anim.SetFloat("MoveY", velocityY);
    }
    
}
