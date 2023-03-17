using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebornControl : MonoBehaviour
{
    public int damage;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && GameManager.instance.playerControl != null && !GameManager.instance.IsCloverOn)
        {
            //Debug.Log(";k");
            //GameManager.instance.playerControl.HitPlayer(damage);
            animator.SetTrigger("IsAtac");
        }
        else if (collision.tag == "Drop")
        {
            StartCoroutine(DieFire());
        }
        else if (collision.tag == "Seed")
        {
            animator.SetTrigger("IsAtac");
            Destroy(collision);
        }
    }

    IEnumerator DieFire()
    {
        animator.SetTrigger("IsDie");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
