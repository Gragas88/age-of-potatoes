using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private Animator animator;

    public Transform target;

    public void Start()
    {
        animator = GetComponent<Animator>();
        Move();
    }

    private void Move()
    {
        animator.SetBool("walk", true);
        var targetPos = transform.position + Vector3.right * 10f;
        StartCoroutine(MoveTo(30f, targetPos));
        
    }
    
    private IEnumerator MoveTo(float time, Vector3 targetPos)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
