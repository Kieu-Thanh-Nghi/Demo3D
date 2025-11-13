using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] Transform playerFoot;
    [SerializeField] Animator anim;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float reachingRadius;
    [SerializeField] UnityEvent OnDestinationReached, OnStartMoving;

    // Update is called once per frame
    void Update()
    {
        //calculate distance between player and zombie
        float distance = Vector3.Distance(transform.position, playerFoot.position);
        //compair distance and reaching radius

        //case chasing player
        if (distance > reachingRadius)
        {
            agent.isStopped = false;
            agent.SetDestination(playerFoot.position);
            anim.SetBool("isWalking", true);
            OnStartMoving.Invoke();
        }
        

        //case destination reached
        else
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
            OnDestinationReached.Invoke();
        }
    }
}
