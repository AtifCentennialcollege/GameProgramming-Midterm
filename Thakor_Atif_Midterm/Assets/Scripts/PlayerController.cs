using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 500.0f;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;


    private Rigidbody2D rBody;
    private Animator anim;
    private bool isGrounded = false;
    private float duck;
    private bool isDucking = false;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
            }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        isGrounded = GroundCheck();

        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rBody.AddForce(new Vector2(0.0f, jumpForce));
            isGrounded = false;
        }

        duck = Input.GetAxis("Duck");

        Duck();


        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        if(isFacingRight && rBody.velocity.x < 0)
        {
            Flip();
        }
        else if (!isFacingRight && rBody.velocity.x > 0)
        {
            Flip();
        }

        anim.SetFloat("xVelocity", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("yVelocity", Mathf.Abs(rBody.velocity.y));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDucking", isDucking);

    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, whatIsGround);
           
    }

    private void Duck()
    {
        if((duck != 0) && isGrounded)
        {
            isDucking = true;
        }
        else
        {
            isDucking = false;
        }
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
}
