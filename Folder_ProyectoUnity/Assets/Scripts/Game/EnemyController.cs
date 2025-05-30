using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Graph<string, Vector3> grafo = new Graph<string, Vector3>();
    public string nodoActual;
    private string siguienteNodo;
    private float velocidad = 2f;

    void Awake()
    {
        // Crear nodos con posiciones
        grafo.AddNodeGraph("A", new Vector3(0, 0, 0));
        grafo.AddNodeGraph("B", new Vector3(5, 0, 0));
        grafo.AddNodeGraph("C", new Vector3(5, 0, 5));
        grafo.AddNodeGraph("D", new Vector3(0, 0, 5));

        // Conexiones
        grafo.AddEdge("A", "B");
        grafo.AddEdge("B", "C");
        grafo.AddEdge("C", "D");
        grafo.AddEdge("D", "A"); // Patrulla cir
    }
    void Start()
    {
        // Iniciar en nodo A
        nodoActual = "A";
        siguienteNodo = grafo.NodeGraphs[nodoActual].Neighbors[0].Value.ToString();
    }
    void Update()
    {
        Vector3 destino = grafo.NodeGraphs[siguienteNodo].Value;
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            nodoActual = siguienteNodo;

            var vecinos = grafo.NodeGraphs[nodoActual].Neighbors;

            // Obtener el siguiente nodo (vecino distinto del anterior)
            foreach (var vecino in vecinos)
            {
                // Buscamos el nodo que coincida con el objeto vecino
                var nodo = grafo.NodeGraphs.FirstOrDefault(x => x.Value == vecino);

                // Verificamos si se encontr� un nodo y si es distinto del actual
                if (!nodo.Equals(default(KeyValuePair<string, NodeGraph<Vector3>>)) && nodo.Key != siguienteNodo)
                {
                    siguienteNodo = nodo.Key;
                    break;
                }
            }


        }
    }
}
