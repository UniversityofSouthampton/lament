using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy_Wrought : MonoBehaviour
{
    public RoomManager roomManager;

    [Header("Stats")]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBetweenShots;
    private float timeBetweenShots; 
    public float duration = 1f;
    public bool isAttacking;
    public bool isDead = false;


    [Header("References")]
    public GameObject Attack_Wrought;
    private Transform player;
    private Coroutine currentCoroutine;

    [Header("Health")]
    public float maxHealth = 3f;
    public float currentHealth;
    
    Animator anim;
    private Rigidbody2D rb2d;
    private float velocityX;
    private float velocityY;
    private DamageFlash damageFlash;
    
    AudioManager audioManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        isAttacking = false;
        
        damageFlash = GetComponent<DamageFlash>();
    }

    void Update()
    {
        Animate();

        HandleMovement();
        HandleAttack();
        //HandleLook();
    }

    void HandleMovement()
    {
        if(isAttacking)
        {
            transform.position = this.transform.position;
        }
        else
        {
            if(Vector2.Distance(transform.position, player.position) < nearDistance)
            {
                //transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                transform.position = this.transform.position;
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
        
    }

    void HandleAttack()
    {
        if(timeBetweenShots <= 0 && (Vector2.Distance(transform.position, player.position) < nearDistance))
        {
            timeBetweenShots = startTimeBetweenShots;
            currentCoroutine = StartCoroutine(ActivateAttackForSeconds(2f));
            isAttacking = true;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    void HandleLook()
    {
        if (player != null && !isAttacking)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Set the rotation to face the player (only around the Z-axis)
            directionToPlayer.z = 0;  // Ignore any difference in Z-axis (2D plane)
            
            if (directionToPlayer != Vector3.zero)  // Avoid errors if enemy and player are at the same position
            {
                // Calculate the angle in radians and convert to degrees
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

                // Rotate the enemy to face the player
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
        IEnumerator ActivateAttackForSeconds(float duration)
    {
        // Activate the attack object
        if (Attack_Wrought != null)
        {
            yield return new WaitForSeconds(1f);
            Attack_Wrought.SetActive(true);
            anim.SetTrigger("isAttacking");
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(0.2f);

        // Deactivate the attack object
        if (Attack_Wrought != null)
        {
            Attack_Wrought.SetActive(false);
            isAttacking = false;
            StopCoroutine(currentCoroutine); // Stop the specific coroutine
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("isHurt");
        damageFlash.CallDMGFlash();
        if(currentHealth <= 0)
        {
            anim.SetTrigger("isDead");
            StartCoroutine(DestroyEnemy());
            roomManager.EnemyKilled(gameObject);
        }
    }
    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        isDead = true;
        yield return new WaitForSeconds(1f);
        Debug.Log("wrought has been killed");
        Destroy(gameObject);
    }

    void Animate()
    {
        anim.SetFloat("MoveX", velocityX);
        anim.SetFloat("MoveY", velocityY);
    }
}
