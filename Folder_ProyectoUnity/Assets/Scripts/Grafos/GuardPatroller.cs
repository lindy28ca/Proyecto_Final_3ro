using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class GuardPatroller : MonoBehaviour
{
    public PatrolGraphInitializer graphInitializer;
    public int startNodeIndex = 0;
    public float attackRange = 2f;

    private Animator alex;
    private NavMeshAgent agent;
    private List<int> patrolPath;
    private int currentTargetIndex = 0;

    private StateEnemy state;
    private Transform transformsPlayer;

    private void Awake()
    {
        alex = GetComponent<Animator>();
    }

    void Start()
    {
        state = StateEnemy.Patrol;
        agent = GetComponent<NavMeshAgent>();
        patrolPath = graphInitializer.graph.BFS(startNodeIndex);

        if (patrolPath.Count > 0)
        {
            GoToNextNode();
        }
    }

    void Update()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        switch (state)
        {
            case StateEnemy.Patrol:
                alex.SetTrigger("Caminar");
                if (!agent.pathPending && agent.remainingDistance < 0.2f)
                {
                    currentTargetIndex = (currentTargetIndex + 1) % patrolPath.Count;
                    GoToNextNode();
                }
                break;

            case StateEnemy.Follow:
                if (transformsPlayer != null)
                {
                    float distance = Vector3.Distance(transform.position, transformsPlayer.position);

                    if (distance <= attackRange)
                    {
                        state = StateEnemy.Attack;
                    }
                    else
                    {
                        agent.SetDestination(transformsPlayer.position);
                        alex.SetTrigger("Caminar");
                    }
                }
                break;

            case StateEnemy.Attack:
                if (transformsPlayer != null)
                {
                    float distance = Vector3.Distance(transform.position, transformsPlayer.position);

                    if (distance > attackRange)
                    {
                        state = StateEnemy.Follow;
                    }
                    else
                    {
                        agent.ResetPath();
                        alex.SetTrigger("Atacar");
                    }
                }
                break;
        }
    }

    private void GoToNextNode()
    {
        int nodeId = patrolPath[currentTargetIndex];
        Transform targetTransform = graphInitializer.graph.NodeGraphs[nodeId].Value;
        agent.SetDestination(targetTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transformsPlayer = other.transform;
            state = StateEnemy.Follow;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transformsPlayer = null;
            state = StateEnemy.Patrol;
        }
    }

    private enum StateEnemy
    {
        Patrol,
        Follow,
        Attack
    }
}
