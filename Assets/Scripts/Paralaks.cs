using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralaks : MonoBehaviour
{
    [SerializeField] Transform follingTarget;
    [SerializeField, Range(0f, 1f)] float speed;

    Vector3 targetPrevious;

    private void Start()
    {
        if (!follingTarget)
        {
            follingTarget = Camera.main.transform;
        }

        targetPrevious = follingTarget.position;
    }

    private void Update()
    {
        var delta = follingTarget.position - targetPrevious;

        targetPrevious = follingTarget.position;
        transform.position += delta * speed;
    }
}
