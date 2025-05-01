using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   private PlayerControllerNew playerController;

    [Header("Health Stats")]

    public float maxHealth;
    public float currentHealth;
    public float iFrames = 0.5f;
    public bool isDead = false;
    private bool canTakeDamage = true;

    public float dmgMultiplier = 1;
    public GameObject player;
    Animator anim;
    private DamageFlash damageFlash;
    AudioManager audioManager;

    public SpriteRenderer playerSr;
    public PlayerControllerNew playerMovement;

    public GameManagerScript gameManager;

    public void Start()
    {
        if(PlayerStatsManager.Instance != null)
        {
            maxHealth = PlayerStatsManager.Instance.maxHealth;
        }

        currentHealth = maxHealth;
        playerController = GetComponent<PlayerControllerNew>(); 
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
        player.GetComponent<AttackNew>().enabled = true;
        damageFlash = GetComponent<DamageFlash>();

    }

    public void Update()
    {
        currentHealth = PlayerStatsManager.Instance.currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (!playerController.isDashing && canTakeDamage)
        {
            currentHealth -= damage;
            PlayerStatsManager.Instance.currentHealth -= damage;
            StartCoroutine(IsDamaged());
            //Debug.Log("Player health: " + currentHealth);
            audioManager.PlaySfx(audioManager.playerhurt);
            anim.SetTrigger("isHurt");
            damageFlash.CallDMGFlash();

            if (currentHealth <= 0 && !isDead)
            {
                audioManager.PlaySfx(audioManager.playerdeath);
                gameManager.gameOver();
                anim.SetTrigger("isDead");
                player.GetComponent<AttackNew>().enabled = false;
                StartCoroutine(DestroyPlayer());
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
        if (CompareTag("Damage"))
        {
            TakeDamage(1);

        }
    }
}