using System.Collections.Generic;
using UnityEngine;

public class NodeGraph<T>
{
    public T Value { get; set; }
    public List<NodeGraph<T>> Neighbors { get; private set; }
    public object Key { get; set; }  // clave genérica

    public NodeGraph(T value)
    {
        Value = value;
        Neighbors = new List<NodeGraph<T>>();
    }

    public void AddNeighbor(NodeGraph<T> neighbor)
    {
        if (!Neighbors.Contains(neighbor))
        {
            Neighbors.Add(neighbor);
        }
    }

}
