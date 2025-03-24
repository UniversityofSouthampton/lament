using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerControllerNew playerController;

    [Header("Health Stats")]

    public float maxHealth = 5;
    public float currentHealth;
    public float iFrames = 0.5f;
    public bool isDead = false;
    private bool canTakeDamage = true;

    public float dmgMultiplier = 1;
    public GameObject player;
    Animator anim;

    public SpriteRenderer playerSr;
    public PlayerControllerNew playerMovement;

    public GameManagerScript gameManager;
    public void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerControllerNew>();
        anim = GetComponent<Animator>();
        player.GetComponent<AttackNew>().enabled = true;
    }
    
    public void TakeDamage(int damage)
    {
        if(!playerController.isDashing && canTakeDamage)
        {
            currentHealth -= damage;
            StartCoroutine(IsDamaged());
            //Debug.Log("Player health: " + currentHealth);
            anim.SetTrigger("isHurt");
            
            if (currentHealth <= 0 && !isDead)
            {
                anim.SetTrigger("isDead");
                player.GetComponent<AttackNew>().enabled = false;
                StartCoroutine(DestroyPlayer());
                gameManager.gameOver();
            }
        }
        else
        {
            return;
        }
    }

    private IEnumerator IsDamaged()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(iFrames);
        canTakeDamage = true;
    }
    private IEnumerator DestroyPlayer()
    {
        isDead = true;
        yield return new WaitForSeconds(1f);
        Debug.Log("Player has been killed");
        playerSr.enabled = false;
        playerMovement.enabled = false;
    }
    
    
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(CompareTag("Damage"))
        {
            TakeDamage(1);
           
        }
    }
    
}
