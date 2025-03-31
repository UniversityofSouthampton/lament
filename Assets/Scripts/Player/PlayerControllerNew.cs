using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerControllerNew : MonoBehaviour
{
    [Header("Movement")]
    private AttackNew attackScript;
    private PlayerHealth healthScript;
    public float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    [Header("Dash Settings")]
    private float activeMoveSpeed;
    public float dashSpeed = 15f;
    public float dashDuration = 0.45f;
    public float dashCooldown = 0.5f;

    public bool isDashing = false;
    private bool canDash = true;

    [Header("References")]
    Animator anim;
    public int playerLayer;
    public int pitFallLayer;

    [Header("Checks")]
    private Vector2 lastMoveDirection;
    public Transform Aim;
    bool isWalking = false;
    public bool isFalling = false;
    
    [Header("FacingDirection")]
    public bool isFacingLeft = false;
    public bool isFacingRight = false;
    public bool isFacingUp = false;
    public bool isFacingDown = false;
    [SerializeField] private TrailRenderer tr;

    AudioManager audioManager;

    void Start()
    {
        pitFallLayer = LayerMask.NameToLayer("PlayerCanDashOver");

        canDash = true;
        anim = GetComponent<Animator>();
        activeMoveSpeed = moveSpeed;
        attackScript = GetComponent<AttackNew>();
        healthScript = GetComponent<PlayerHealth>();
      audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        Animate();
        
        if (isDashing && healthScript.isDead)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space) && canDash && !attackScript.isAttacking && !healthScript.isDead)
        {
            Vector2 dashDirection = lastMoveDirection;
                 if(moveInput is { x: > 0, y: 0 }) {dashDirection = Vector2.right;}
            else if(moveInput is { x: < 0, y: 0 }) {dashDirection = Vector2.left;}
            else if(moveInput is { x: 0, y: > 0 }) {dashDirection = Vector2.up;}
            else if(moveInput is { x: 0, y: < 0 }) {dashDirection = Vector2.down;}
            StartCoroutine(Dash(dashDirection));
            Debug.Log("isdashing");
        }

        if(healthScript.isDead)
        {
            rb2d.velocity = Vector2.zero;
        }

        if(!isDashing && !healthScript.isDead)
        {
            if(!attackScript.isAttacking)
            {
                rb2d.velocity = moveInput * moveSpeed;
            }
            else
            {
                rb2d.velocity = Vector2.zero;
            }
            
            ProcessInputs();
        }

        

    }
    IEnumerator Dash(Vector2 direction)
    {
        Debug.Log("Is Dashing");
        canDash = false;
        isDashing = true;
       Physics2D.IgnoreLayerCollision(gameObject.layer, pitFallLayer, true);
        audioManager.PlaySfx(audioManager.dash);
        anim.SetBool("isDashing", true);
        tr.emitting = true;
       // rb2d.isKinematic = true;
       //This hanndles the direction of the dash based on player's last movement

       rb2d.velocity = direction * dashSpeed;
       //rb2d.velocity = new Vector2(moveInput.x * dashSpeed, moveInput.y * dashSpeed);
        
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        Physics2D.IgnoreLayerCollision(gameObject.layer, pitFallLayer, false);
        anim.SetBool("isDashing", false);
        tr.emitting = false;
       // rb2d.isKinematic = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void ProcessInputs()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        if(!attackScript.isAttacking)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if((moveX == 0 && moveY == 0) && (moveInput.x !=0 || moveInput.y !=0))
            {
                isWalking = false;
                lastMoveDirection = moveInput;
            }
            else if (moveX != 0 || moveY != 0)
            {
                isWalking = true;
            }
            

            moveInput.Normalize();
            rb2d.velocity = moveInput * activeMoveSpeed;            
        }

        //Handle facing direction

        if (moveInput.x > 0)
        {
            SetFacingDirection(false, true, false, false); // Facing right
        }
        else if (moveInput.x < 0)
        {
            SetFacingDirection(true, false, false, false); // Facing left
        }
        else if (moveInput.y > 0)
        {
            SetFacingDirection(false, false, true, false); // Facing up
        }
        else if (moveInput.y < 0)
        {
            SetFacingDirection(false, false, false, true); // Facing down
        }        
    }

    private void SetFacingDirection(bool right, bool left, bool up, bool down)
    {
        isFacingRight = right;
        isFacingLeft = left;
        isFacingUp = up;
        isFacingDown = down;

        /*if (isFacingRight)
        {
            Debug.Log("Player is facing Right");
        }
        else if (isFacingLeft)
        {
            Debug.Log("Player is facing Left");
        }
        else if (isFacingUp)
        {
            Debug.Log("Player is facing Up");
        }
        else if (isFacingDown)
        {
            Debug.Log("Player is facing Down");
        }*/

    }

    public void Fall()
    {
        //play animation
    }

    void Animate()
    {
        anim.SetFloat("MoveX", moveInput.x);
        anim.SetFloat("MoveY", moveInput.y);
        anim.SetFloat("MoveMagnitude", moveInput.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
        if (isFacingRight)
        {
            anim.SetFloat("isAttacking 1", 0.25f);
        }
        else if (isFacingLeft)
        {
            anim.SetFloat("isAttacking 1", 0.75f);
        }
        else if (isFacingUp)
        {
            anim.SetFloat("isAttacking 1", 0f);
        }
        else if (isFacingDown)
        {
            anim.SetFloat("isAttacking 1", 0.5f);
        }
    }
}