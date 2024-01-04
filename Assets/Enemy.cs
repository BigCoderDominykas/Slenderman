using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float viewDistance = 20;
    public float wanderDistance = 10;
    public float speed;
    public Transform target;

    public Animator animator;
    Rigidbody rb;
    NavMeshAgent agent;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator.Play("Idle");
    }

    void Update()
    {
        if (target == null) return;

        agent.speed = speed;

        if (agent.velocity != Vector3.zero)
        {
            animator.Play("Run");
        }
        else
        {
            animator.Play("Idle");
        }

        var distance = Vector3.Distance(transform.position, target.position);

        if (distance < viewDistance)
        {
            // CHASE
            agent.destination = target.position;
        }
        else
        {
            // SEEK
            // Random.Range(0,120) == 1
            if (agent.velocity == Vector3.zero)
            {
                agent.destination += Random.insideUnitSphere * wanderDistance;
            }
        }
    }
}