using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SeedDropControl: MonoBehaviour
{
    public Transform spawnPlant;
    public GameObject plant;
    public GameObject drop;
    public Rigidbody2D rb;

    public float forseX = 100f;
    public float forseY = 100f;
    public float forseAll = 100f;

    public Transform player;

    public Transform GroundCheck;
    public bool isGround = false;
    public float GrounRagius;
    public LayerMask isGrouned;

    public bool isPlantOn;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
        StartCoroutine(DestroyDrop(5));
    }

    IEnumerator DestroyDrop(int DestroyTime)
    {
        yield return new WaitForSeconds(DestroyTime);
        if (!isPlantOn)
        {
        Destroy(drop);
        }
    }

    public void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(GroundCheck.position, GrounRagius, isGrouned);

        if (isGround)
        {
            rb.isKinematic = false;
            plant.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            MoveDownDrop();
            StartCoroutine(DestroyDrop(2));
        }
    }

    private void MoveDownDrop()
    {
        Vector2 vector2 = new Vector2(0, -5);
        rb.AddForce(vector2, ForceMode2D.Impulse);
    }
}
