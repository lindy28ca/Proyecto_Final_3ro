using UnityEngine;
using System.Collections.Generic;

public class PatrolGraphInitializer : MonoBehaviour
{
    public Transform[] patrolPoints; 
    public Graph<int, Transform> graph = new Graph<int, Transform>();

    void Awake()
    {
        
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            graph.AddNodeGraph(i, patrolPoints[i]);
        }

        
        for (int i = 0; i < patrolPoints.Length - 1; i++)
        {
            graph.AddEdge(i, i + 1);
        }

        // Cerrar el ciclo (opcional)
        graph.AddEdge(patrolPoints.Length - 1, 0);
    }
}

