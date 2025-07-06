using System.Collections.Generic;
using UnityEngine;

public class NodeGraph<T>
{
    #region Propiedades

    public T Value { get; set; }
    public List<NodeGraph<T>> Neighbors { get; private set; }
    public object Key { get; set; }

    #endregion

    #region Constructor

    public NodeGraph(T value)
    {
        Value = value;
        Neighbors = new List<NodeGraph<T>>();
    }

    #endregion

    #region AddNeighbor

    public void AddNeighbor(NodeGraph<T> neighbor)
    {
        if (!Neighbors.Contains(neighbor))
        {
            Neighbors.Add(neighbor);
        }
    }

    #endregion
}
