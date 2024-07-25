using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirroredMovement : MonoBehaviour
{

    public Rigidbody2D original; //normal character
    public Rigidbody2D upsideDown;
    public int walkSpeed;
    public float jumpForce;
    private bool isGrounded1 = true;
    private bool isGrounded2 = true;
    private bool isFacingRight1 = true;
    private bool isFacingRight2 = true;
    private Animator anim1;
    private Animator anim2;
    private int maxJumps = 1;
    private int jumpsLeft;
    // Start is called before the first frame update
    void Start()
    {
        anim1 = original.GetComponent<Animator>();
        anim2 = upsideDown.GetComponent<Animator>(); 
        jumpsLeft = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        float walkInput = Input.GetAxis("Horizontal");
        //normal movement 
        original.velocity = new Vector2(walkInput * walkSpeed, original.velocity.y);
        AnimateCharacter(original, anim1, walkInput, ref isGrounded1, ref isFacingRight1);
        //mirrored movement 
        upsideDown.velocity = new Vector2(walkInput * walkSpeed, upsideDown.velocity.y);
        AnimateCharacter(upsideDown, anim2, walkInput, ref isGrounded2, ref isFacingRight2);

        if(Input.GetKey(KeyCode.UpArrow) && jumpsLeft > 0)
        {
            original.velocity = new Vector2(original.velocity.x, jumpForce);
            upsideDown.velocity = new Vector2(upsideDown.velocity.x, -jumpForce);
            jumpsLeft--;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            anim1.SetBool("isJumping", false);
            anim2.SetBool("isJumping", false);
            jumpsLeft++;
        }
    }

    private void AnimateCharacter(Rigidbody2D rb, Animator anim, float walkInput, ref bool isGrounded, ref bool isFacingRight)
    {
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
            Flip(ref isFacingRight, rb.transform);
        }
        if(!isFacingRight && walkInput > 0f)
        {
            Flip(ref isFacingRight, rb.transform);
        }
        if(rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", true);
        }
    }

    private void Flip(ref bool isFacingRight, Transform transform)
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
