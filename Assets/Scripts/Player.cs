using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedRun;
    public float speedUp;
    public float moveInput;

    public bool isRigth;

    private Rigidbody2D rb;

    public Animator animator;

    public Transform GroundCheck;
    public bool isGround = false;
    public float GrounRagius;
    public LayerMask isGrouned;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");

        animator.SetFloat("IsRun", Mathf.Abs(moveInput));

        rb.velocity = new Vector3(moveInput * speedRun, rb.velocity.y);
    }

    public void FlipHero()
    {
        isRigth = !isRigth;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Update()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, GrounRagius, isGrouned);

        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = Vector2.up * speedUp;
        }

        if (!isGround)
        {
            animator.SetBool("IsJump", true);
        }
        else if (isGround)
        {
            animator.SetBool("IsJump", false);
        }

        if(moveInput > 0 && isRigth)
        {
            FlipHero();
        }
        else if (moveInput < 0 && !isRigth)
        {
            FlipHero();
        }
    }
}
