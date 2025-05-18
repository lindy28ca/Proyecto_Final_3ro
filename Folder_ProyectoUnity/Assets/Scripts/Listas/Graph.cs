using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI.Table;
using System.Linq;

public class Graph<TKey, TNodeGraphValue>
{
    public Dictionary<TKey, NodeGraph<TNodeGraphValue>> NodeGraphs { get; private set; }

    public Graph()
    {
        NodeGraphs = new Dictionary<TKey, NodeGraph<TNodeGraphValue>>();
    }

    public bool AddNodeGraph(TKey key, TNodeGraphValue value)
    {
        if (NodeGraphs.ContainsKey(key))
            return false;

        NodeGraphs[key] = new NodeGraph<TNodeGraphValue>(value);
        return true;
    }

    public void AddEdge(TKey key1, TKey key2)
    {
        if (!NodeGraphs.ContainsKey(key1) || !NodeGraphs.ContainsKey(key2))
        {
            Debug.LogWarning("Uno o ambos nodos no existen en el grafo.");
            return;
        }

        NodeGraph<TNodeGraphValue> n1 = NodeGraphs[key1];
        NodeGraph<TNodeGraphValue> n2 = NodeGraphs[key2];

        n1.AddNeighbor(n2);
        n2.AddNeighbor(n1);
    }

    public void DisplayGraphAsMatrix()
    {
        int size = NodeGraphs.Count;
        if (size == 0)
        {
            Debug.Log("El grafo está vacío.");
            return;
        }

        var keys = new List<TKey>(NodeGraphs.Keys);
        var keyToIndex = new Dictionary<TKey, int>();
        var NodeGraphToKey = new Dictionary<NodeGraph<TNodeGraphValue>, TKey>();
        int[,] matrix = new int[size, size];

        for (int i = 0; i < keys.Count; i++)
        {
            keyToIndex[keys[i]] = i;
            NodeGraphToKey[NodeGraphs[keys[i]]] = keys[i];
        }

        foreach (var kvp in NodeGraphs)
        {
            int i = keyToIndex[kvp.Key];
            foreach (var neighbor in kvp.Value.Neighbors)
            {
                if (NodeGraphToKey.TryGetValue(neighbor, out TKey neighborKey))
                {
                    int j = keyToIndex[neighborKey];
                    matrix[i, j] = 1;
                    matrix[j, i] = 1; // Simétrico
                }
            }
        }

        PrintAdjacencyMatrix(keys, matrix);
    }

    private void PrintAdjacencyMatrix(List<TKey> keys, int[,] matrix)
    {
        string header = "".PadRight(6);
        foreach (var key in keys)
            header += $"{key.ToString().PadRight(6)}";

        Debug.Log(header);

        for (int i = 0; i < keys.Count; i++)
        {
            string row = $"{keys[i].ToString().PadRight(6)}";
            for (int j = 0; j < keys.Count; j++)
            {
                row += (matrix[i, j] == 1 ? "Si" : "No").PadRight(6);
            }
            Debug.Log(row);
        }
    }

    public void DisplayGraphAsList()
    {
        var NodeGraphToKey = new Dictionary<NodeGraph<TNodeGraphValue>, TKey>();
        foreach (var kvp in NodeGraphs)
        {
            NodeGraphToKey[kvp.Value] = kvp.Key;
        }

        foreach (var kvp in NodeGraphs)
        {
            string line = $"Nodo {kvp.Key}: ";
            foreach (var neighbor in kvp.Value.Neighbors)
            {
                if (NodeGraphToKey.TryGetValue(neighbor, out TKey neighborKey))
                {
                    line += $"{neighborKey}, ";
                }
            }
            Debug.Log(line.TrimEnd(' ', ','));
        }
    }
    public List<TKey> BFS(TKey startKey)
    {
        var visitados = new HashSet<NodeGraph<TNodeGraphValue>>();
        var resultado = new List<TKey>();

        if (!NodeGraphs.ContainsKey(startKey))
            return resultado;

        var cola = new Queue<NodeGraph<TNodeGraphValue>>();
        var startNodeGraph = NodeGraphs[startKey];
        cola.Enqueue(startNodeGraph);
        visitados.Add(startNodeGraph);

        var NodeGraphToKey = NodeGraphs.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        while (cola.Count > 0)
        {
            var actual = cola.Dequeue();
            resultado.Add(NodeGraphToKey[actual]);

            foreach (var vecino in actual.Neighbors)
            {
                if (!visitados.Contains(vecino))
                {
                    visitados.Add(vecino);
                    cola.Enqueue(vecino);
                }
            }
        }

        return resultado;
    }
    public List<TKey> DFS(TKey startKey)
    {
        var visitados = new HashSet<NodeGraph<TNodeGraphValue>>();
        var resultado = new List<TKey>();

        if (!NodeGraphs.ContainsKey(startKey))
            return resultado;

        var NodeGraphToKey = NodeGraphs.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        void DFSRecursivo(NodeGraph<TNodeGraphValue> actual)
        {
            visitados.Add(actual);
            resultado.Add(NodeGraphToKey[actual]);

            foreach (var vecino in actual.Neighbors)
            {
                if (!visitados.Contains(vecino))
                {
                    DFSRecursivo(vecino);
                }
            }
        }

        DFSRecursivo(NodeGraphs[startKey]);
        return resultado;
    }


    public List<TKey> FindPathBFS(TKey startKey, TKey targetKey)
    {
        var path = new List<TKey>();

        if (!NodeGraphs.ContainsKey(startKey) || !NodeGraphs.ContainsKey(targetKey))
            return path;

        var startNodeGraph = NodeGraphs[startKey];
        var targetNodeGraph = NodeGraphs[targetKey];

        var visited = new HashSet<NodeGraph<TNodeGraphValue>>();
        var parentMap = new Dictionary<NodeGraph<TNodeGraphValue>, NodeGraph<TNodeGraphValue>>();
        var queue = new Queue<NodeGraph<TNodeGraphValue>>();

        queue.Enqueue(startNodeGraph);
        visited.Add(startNodeGraph);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current == targetNodeGraph)
                break;

            foreach (var neighbor in current.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parentMap[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Si no se encontró el target
        if (!parentMap.ContainsKey(targetNodeGraph) && startNodeGraph != targetNodeGraph)
            return path;

        // Reconstruir el camino desde el target hacia el start
        var currentNodeGraph = targetNodeGraph;
        var NodeGraphToKey = NodeGraphs.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

        while (currentNodeGraph != null)
        {
            path.Insert(0, NodeGraphToKey[currentNodeGraph]);
            parentMap.TryGetValue(currentNodeGraph, out currentNodeGraph);
        }

        return path;
    }
}
