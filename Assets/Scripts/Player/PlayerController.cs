using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement
    public float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    [Header("Dash Settings")]
    private float activeMoveSpeed;
    public float dashSpeed = 10f;
    public float dashDuration = 1f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private bool canDash = true;

    //trail
    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        canDash = true;
        activeMoveSpeed = moveSpeed;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();
        rb2d.velocity = moveInput * activeMoveSpeed;

        if(Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        tr.emitting = true;
        rb2d.velocity = new Vector2(moveInput.x * dashSpeed, moveInput.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        tr.emitting = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}