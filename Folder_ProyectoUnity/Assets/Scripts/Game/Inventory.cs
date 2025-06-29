using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image[] image;
    [SerializeField] private ItemsInformation[] itemInformation; // SOLO incluye aquí la pinza si deseas
    [SerializeField] private Transform tarjet;

    private CircularDoubleLinkedList<ItemsInformation> listaCircular = new CircularDoubleLinkedList<ItemsInformation>();
    private Node<ItemsInformation> currentNode;

    private void Start()
    {
        // Solo agrega objetos iniciales (como la pinza), si hay
        for (int i = 0; i < itemInformation.Length; i++)
        {
            Add(itemInformation[i]);
        }

        currentNode = listaCircular.Head;
        UpdateImages();
    }

    public void Add(ItemsInformation information)
    {
        if (!listaCircular.ToList().Contains(information))
        {
            listaCircular.Add(information);
            information.ItemTranform.position = tarjet.position;
            information.ItemTranform.SetParent(tarjet);
            information.UpdateRotation();
            information.ItemTranform.gameObject.SetActive(false);
            UpdateImages();
        }
    }

    public bool Contiene(string nombre)
    {
        foreach (var nodo in listaCircular.ToList())
        {
            if (nodo.pinza == nombre)
            {
                return true;
            }
        }
        return false;
    }

    public bool PinzaEnMano(string nombre)
    {
        if (currentNode == null || currentNode.Value == null) return false;
        return currentNode.Value.pinza == nombre;
    }

    private void Next() => currentNode = currentNode.Next;
    private void Previous() => currentNode = currentNode.Prev;

    private void UpdateImages()
    {
        Node<ItemsInformation> tempNode = currentNode;
        for (int i = 0; i < image.Length; i++)
        {
            if (tempNode != null)
            {
                image[i].sprite = tempNode.Value.ItemSprite;
                tempNode = tempNode.Next;
            }
            else
            {
                image[i].sprite = null;
            }
        }
    }

    public void GetInputScroll(float valorInput)
    {
        if (listaCircular.Count <= 1) return;
        currentNode.Value.ItemTranform.gameObject.SetActive(false);
        if (valorInput < 0) Previous();
        else if (valorInput > 0) Next();
        currentNode.Value.ItemTranform.gameObject.SetActive(true);
        UpdateImages();
    }

    private void OnEnable() => InputReader.OnScroll += GetInputScroll;
    private void OnDisable() => InputReader.OnScroll -= GetInputScroll;
}
