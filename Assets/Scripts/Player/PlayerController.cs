using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement
    [Header("Movement")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    bool isWalking = false;
    private Vector2 lastMoveDirection;

    [Header("Dash Settings")]
    private float activeMoveSpeed;
    public float dashSpeed = 12f;
    public float dashDuration = 0.25f;
    public float dashCooldown = 0.5f;

    public bool isDashing = false;
    private bool canDash = true;

    [Header("References")]
    Animator anim;
    public Transform Aim;
    private Attack attackScript;


    //trail
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        canDash = true;
        anim = GetComponent<Animator>();
        activeMoveSpeed = moveSpeed;
        attackScript = GetComponent<Attack>();
    }

    void Update()
    {
        Animate();

        if (isDashing)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

        if(!isDashing)
        {
            ProcessInputs();
        }
        

    }
    IEnumerator Dash()
    {
        Debug.Log("Is Dashing");
        canDash = false;
        isDashing = true;
        anim.SetBool("isDashing", true);
        tr.emitting = true;
        rb2d.velocity = new Vector2(moveInput.x * dashSpeed, moveInput.y * dashSpeed);
        
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        anim.SetBool("isDashing", false);
        tr.emitting = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void FixedUpdate()
    {
        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * moveInput.x + Vector3.down * moveInput.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }

        if(!attackScript.isAttacking)
        {
            rb2d.velocity = moveInput * moveSpeed;
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
    void ProcessInputs()
    {
        if(!attackScript.isAttacking)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if ((attackScript.isAttacking) || ((moveX == 0 && moveY == 0) && (moveInput.x !=0 || moveInput.y !=0)))
            {
                isWalking = false;
                lastMoveDirection = moveInput;
                Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
                Aim.rotation = Quaternion.LookRotation(Vector3.forward,vector3);
            }
            else if (moveX != 0 || moveY != 0)
            {
                isWalking = true;
            }
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();
            rb2d.velocity = moveInput * activeMoveSpeed;
        
        }
        else
        {
            moveInput = Vector2.zero;
            Aim.rotation = this.Aim.rotation;
        }

    }
    void Animate()
    {
        anim.SetFloat("MoveX", moveInput.x);
        anim.SetFloat("MoveY", moveInput.y);
        anim.SetFloat("MoveMagnitude", moveInput.magnitude);
        anim.SetFloat("LastMoveX", lastMoveDirection.x);
        anim.SetFloat("LastMoveY", lastMoveDirection.y);
    }
}