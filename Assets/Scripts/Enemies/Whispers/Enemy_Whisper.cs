    using System;
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
    public bool isDead = false;

    [Header("References")]
    public GameObject projectile;
    public GameObject TerraShard;
    private Transform player;

    [Header("Health")]
    public float maxHealth = 3f;
    public float currentHealth;

    Animator anim;
    private Rigidbody2D rb2d;
    private float velocityX;
    private float velocityY;
    private DamageFlash damageFlash;
    
    AudioManager audioManager;
    private AudioSource voiceSource;

   //hasspawned bool for delaying activation and isbeingattacked delays shooting when they are attacked at the same speed as the attack animation
    private bool hasSpawned = false;
    private bool isBeingAttacked = false;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        voiceSource = gameObject.AddComponent<AudioSource>();
        voiceSource.clip = audioManager.whispervoice;
        voiceSource.loop = true;
        voiceSource.Play(); 
        
        damageFlash = GetComponent<DamageFlash>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1f);
        hasSpawned = true;
    }
    void Update()
    {
        if (hasSpawned)
        {  
            Animate();

            if(!isDead)
            {
                HandleMovement();
                HandleProjectile();
            }
        }
        
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
        if(!isBeingAttacked && timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
           anim.SetTrigger("isAttacking");
            audioManager.PlaySfx(audioManager.whispershoot);
            
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        isBeingAttacked = true;
        StartCoroutine(ResetBeingAttacked());
        anim.SetTrigger("isHurt");
        damageFlash.CallDMGFlash();
        audioManager.PlaySfx(audioManager.whisperhurt);
        //Debug.Log("Whisper health is" + currentHealth);
        if(currentHealth <= 0)
        {
            roomManager.EnemyKilled(gameObject);
            anim.SetTrigger("isDead");
            audioManager.PlaySfx(audioManager.whisperdeath);
            StartCoroutine(DestroyEnemy());
            
        }
        IEnumerator ResetBeingAttacked()
        {
            
            yield return new WaitForSeconds(1f); 
            isBeingAttacked = false;
        }
    }

   //this numerartor delays the whisper death so the animation plays
    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(0.1f);
        isDead = true;
        yield return new WaitForSeconds(0.9f);
        //Debug.Log("Whisper has been killed");
        Destroy(gameObject);
        Instantiate(TerraShard, transform.position, Quaternion.identity);
        voiceSource.Stop();
    }
    
    void Animate()
    {
        anim.SetFloat("MoveX", velocityX);
        anim.SetFloat("MoveY", velocityY);
    }
    
}
