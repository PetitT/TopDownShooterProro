using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public float spotRange;
    public float minRange;
    public float pathRecalculationTimer;
    private float remainingPathCalculationTimer;
    public LayerMask playerLayer;
    public LayerMask obstacleLayer;
    private enum EnnemyState { wander, follow }
    private EnnemyState currentState;
    private Transform target;
    private float distanceFromPlayer;

    private bool canAttack = true;
    private EnnemyAttack currentAttack;

    private void OnEnable()
    {
        currentState = EnnemyState.wander;
        target = null;
        currentAttack = Helper.GetRandomInCollection(GetComponentsInChildren<EnnemyAttack>());
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnnemyState.wander:
                SearchPlayer();
                break;
            case EnnemyState.follow:
                RecalculatePath();
                LookAtPlayer();
                CheckDistance();
                DoAttack();
                break;
            default:
                break;
        }
    }

    private void SearchPlayer()
    {
        Collider[] playerCollider = Physics.OverlapSphere(transform.position, spotRange, playerLayer);
        if (playerCollider.Length > 0)
        {
            Transform player = playerCollider[0].transform;
            target = player;
            currentState = EnnemyState.follow;
        }
    }

    private void LookAtPlayer()
    {
        transform.LookAt(target);
        Vector3 currentRot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, currentRot.y, 0);
    }

    private void CheckDistance()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceFromPlayer < minRange)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }

    private void DoAttack()
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(currentAttack.Attack(() => canAttack = true));
        }
    }

    private void RecalculatePath()
    {
        remainingPathCalculationTimer -= Time.deltaTime;
        if (remainingPathCalculationTimer <= 0)
        {
            agent.SetDestination(target.position);
            remainingPathCalculationTimer = pathRecalculationTimer;
        }
    }

}
