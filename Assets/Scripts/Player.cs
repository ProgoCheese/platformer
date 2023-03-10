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
    public SpriteRenderer sprite;

    public Transform GroundCheck;
    public bool isGround = false;
    public float GrounRagius;
    public LayerMask isGrouned;

    public Transform holdPoint;
    public GameObject Drop;

    public bool isHit = false;
    public bool isHitting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isHit = false;
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
        GameManager.instance.IsPlayerRigth = !GameManager.instance.IsPlayerRigth;
        sprite.flipX = GameManager.instance.IsPlayerRigth;
        //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Update()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, GrounRagius, isGrouned);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
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

        if (moveInput > 0 && GameManager.instance.IsPlayerRigth)
        {
            FlipHero();
        }
        else if (moveInput < 0 && !GameManager.instance.IsPlayerRigth)
        {
            FlipHero();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

            Instantiate(Drop, holdPoint);

            //if (Drop.gameObject.GetComponent<Rigidbody2D>() != null)
            //{
            //    Drop.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwOdject;
            //}
        }

        if (isHit && !isHitting)
        {
            Debug.Log("123456");
            isHitting = true;
            StartCoroutine(InvulnerabilityPlayer());
        }
    }

    IEnumerator InvulnerabilityPlayer()
    {
        animator.SetTrigger("IsHit");
        yield return new WaitForSeconds(2);
        isHit = false;
        isHitting = false;
    }

    public void HitPlayer(int hit)
    {
        if (!isHit)
        {
        Debug.Log("DFsG");
            isHit = true;
            GameManager.instance.healhPlayer -= hit;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Seed")
        {
            Destroy(collision.gameObject);
            GameManager.instance.seedCount++;
        }
        //else if(collision.tag == "Fire")
        //{
        //    Debug.Log("df");
        //    HitPlayer(10);
        //}
    }

}
