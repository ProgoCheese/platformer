using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropControl : MonoBehaviour
{
    public GameObject drop;
    public Rigidbody2D rb;
    public Animator anim;

    public float forseX = 100f;
    public float forseY = 100f;
    public float forseAll = 100f;

    public Transform player;

    public Transform GroundCheck;
    public bool isGround = false;
    public float GrounRagius;
    public LayerMask isGrouned;

    private bool isAnim;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Vector2 vector2 = new Vector2(forseX, forseY);
        bool isRigth = GameManager.instance == null ? false : GameManager.instance.IsPlayerRigth;

        if (!isRigth)
        {
            vector2 = new Vector2(forseX, forseY);
        }
        else if (isRigth)
        {
            vector2 = new Vector2(-forseX, forseY);
        }

        rb.AddForce(vector2.normalized * forseAll, ForceMode2D.Impulse);
        isAnim = false;
        StartCoroutine(DestroyDrop(5, isAnim));
    }

    IEnumerator DestroyDrop(int DestroyTime, bool isAnimTime)
    {
        yield return new WaitForSeconds(DestroyTime);
        if (isAnimTime)
        {
            anim.SetTrigger("IsDie");
            yield return new WaitForSeconds(1);
        }
        Destroy(drop);
    }

    public void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, GrounRagius, isGrouned);

        if (isGround)
        {
            isAnim = true;
            rb.isKinematic = false;
            StartCoroutine(DestroyDrop(0, isAnim));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire")
        {
            MoveDownDrop();
            StartCoroutine(DestroyDrop(2, isAnim));
        }
    }

    private void MoveDownDrop()
    {
        Vector2 vector2 = new Vector2(0, -5);
        rb.AddForce(vector2, ForceMode2D.Impulse);
    }
}
