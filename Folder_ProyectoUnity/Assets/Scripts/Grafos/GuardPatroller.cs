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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolPath = graphInitializer.graph.BFS(startNodeIndex); 

        if (patrolPath.Count > 0)
        {
            GoToNextNode();
        }
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            currentTargetIndex = (currentTargetIndex + 1) % patrolPath.Count;
            GoToNextNode();
        }
    }

    void GoToNextNode()
    {
        int nodeId = patrolPath[currentTargetIndex];
        Transform targetTransform = graphInitializer.graph.NodeGraphs[nodeId].Value;
        agent.SetDestination(targetTransform.position);
    }
}

