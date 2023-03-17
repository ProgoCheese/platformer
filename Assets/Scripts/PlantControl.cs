using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControl : MonoBehaviour
{
    public Animator animator;
    public bool isCreat = false;

    private void Start()
    {
        //GameManager.instance.
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isCreat && !GameManager.instance.IsCloverOn)
        {
            animator.SetTrigger("IsDie");
            isCreat = false;
        }
        else if (collision.tag == "Drop" && !isCreat)
        {
            animator.SetTrigger("IsCreating");
            isCreat = true;
        }
    }

    //IEnumerator CreatingPlant()
    //{
    //    yield return new WaitForSeconds(2);
    //}
}