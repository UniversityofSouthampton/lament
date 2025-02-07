using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    [Header("Dash Settings")]
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private bool _isDashing;
    private bool _canDash;

    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDashing)
        {
            return;
        }

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <=0 && dashCounter <=0)
            {
                _canDash = false;
                _isDashing = true;
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                tr.emitting = true;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                _canDash = true;
                _isDashing = false;
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                tr.emitting = false;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
