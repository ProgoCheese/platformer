using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHold : MonoBehaviour
{
    public Transform holdPoint;
    public GameObject Drop;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Instantiate(Drop, holdPoint);

            //if (Drop.gameObject.GetComponent<Rigidbody2D>() != null)
            //{
            //    Drop.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwOdject;
            //}
        }
    }
}
