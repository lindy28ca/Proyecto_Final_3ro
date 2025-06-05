using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class GuardPatroller : MonoBehaviour
{
    public PatrolGraphInitializer graphInitializer;
    public int startNodeIndex = 0;

    private NavMeshAgent agent;
    private List<int> patrolPath;
    private int currentTargetIndex = 0;

    private StateEnemy state;

    private Transform transformsPlayer;
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
        switch(state)
        {
            case StateEnemy.Patrol:
                if (!agent.pathPending && agent.remainingDistance < 0.2f)
                {
                    currentTargetIndex = (currentTargetIndex + 1) % patrolPath.Count;
                    GoToNextNode();
                }
                break;
            case StateEnemy.Follow:
                agent.SetDestination(transformsPlayer.position);
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
        Follow
    }
}

