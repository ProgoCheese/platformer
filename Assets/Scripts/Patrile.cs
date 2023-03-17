using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrile : MonoBehaviour
{
    public float speed;

    public int positionOfPatrol;
    public Transform flyingPoint;
    bool movingRigth;

    Transform player;
    public float stoppingDistance;

    bool chill = false;
    bool angry = false;
    bool goBack = false;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public bool isGood = false;
   // public float flightAltitude = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isGood)
        {
            if (Vector2.Distance(transform.position, flyingPoint.position) < positionOfPatrol && !angry)
            {
                chill = true;
            }
            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
            {
                angry = true;
                chill = false;
                goBack = false;
            }
            else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                goBack = true;
                angry = false;
            }
        }
        else
        {
            chill = true;
        }


        if (chill)
        {
            Chill();
        }
        else if (angry)
        {
            animator.SetBool("IsPlayer", true);
            Angry();
        }
        else if (goBack)
        {
            animator.SetBool("IsPlayer", false);
            GoBack();
        }
    }

    void Chill()
    {
        animator.SetBool("isPlayer", false);
        if (transform.position.x > flyingPoint.position.x + positionOfPatrol)
        {
            movingRigth = false;
        }
        else if (transform.position.x < flyingPoint.position.x - positionOfPatrol)
        {
            movingRigth = true;
        }

        if (movingRigth)
        {
            spriteRenderer.flipX = !movingRigth;
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            spriteRenderer.flipX = !movingRigth;
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        spriteRenderer.flipX = !GameManager.instance.IsPlayerRigth;
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, flyingPoint.position, speed * Time.deltaTime);
    }

    //private void FlyOnFlower()
    //{
    //    Vector2 endPosition = new Vector2(flyingPoint.position.x, flyingPoint.position.y + flightAltitude);
    //    transform.position = Vector2.MoveTowards(transform.position, endPosition, Time.deltaTime * speed);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlantBee" && !isGood)
        {
            isGood = true;
            chill = false;
            angry = false;
            goBack = false;
            animator.SetBool("isPlayer", false);
            animator.SetTrigger("IsGood");
            flyingPoint = collision.transform;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            //FlyOnFlower();
        }
    }
}
