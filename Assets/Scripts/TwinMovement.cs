using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinMovement : MonoBehaviour
{
    public Rigidbody2D twin2rb;
    public int walkSpeed;
    public float jumpForce;
    private bool isGrounded = true;
    private bool isFacingRight = true;
    private int maxJumps = 2;
    private int jumpsLeft;
    private Animator anim;

    void Start()
    {
        twin2rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpsLeft = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        float walkInput = Input.GetAxis("Horizontal");
        twin2rb.velocity = new Vector2(walkInput * walkSpeed, twin2rb.velocity.y);

        if(walkInput != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if(isFacingRight && walkInput < 0f)
        {
            Flip();
        }
        if(!isFacingRight && walkInput > 0f)
        {
            Flip();
        }
        
        if(Input.GetKey(KeyCode.UpArrow) && jumpsLeft > 0)
        {
            twin2rb.velocity = new Vector2(twin2rb.velocity.x, jumpForce);
            jumpsLeft--;
            anim.SetBool("isJumping", true);
        } 

        if(Input.GetKey(KeyCode.DownArrow))
        {
            twin2rb.velocity = new Vector2(twin2rb.velocity.x, -1 * jumpForce);
        }

        if (twin2rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            jumpsLeft = maxJumps;
            anim.SetBool("isJumping", false);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
