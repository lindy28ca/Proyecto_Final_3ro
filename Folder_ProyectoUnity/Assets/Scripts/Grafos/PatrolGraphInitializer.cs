using UnityEngine;
using System.Collections.Generic;

public class PatrolGraphInitializer : MonoBehaviour
{
    #region Variables

    public Transform[] patrolPoints;
    public Graph<int, Transform> graph = new Graph<int, Transform>();

    #endregion

    #region Unity Methods

    private void Awake()
    {
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            graph.AddNodeGraph(i, patrolPoints[i]);
        }

        for (int i = 0; i < patrolPoints.Length - 1; i++)
        {
            graph.AddEdge(i, i + 1);
        }

        graph.AddEdge(patrolPoints.Length - 1, 0);
    }

    #endregion
}