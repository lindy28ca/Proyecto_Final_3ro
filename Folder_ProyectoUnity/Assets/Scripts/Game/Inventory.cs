using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]private Image[] image;
    [SerializeField] private ItemsInformation[] itemInformation;
    private CircularDoubleLinkedList<ItemsInformation> listaCircular = new CircularDoubleLinkedList<ItemsInformation>();
    private Node<ItemsInformation> currentNode;

    private void Start()
    {
        for (int i = 0; i < itemInformation.Length; i++)
        {
            listaCircular.Add(itemInformation[i]);
        } 
    }
    public void Add(ItemsInformation information)
    {
        listaCircular.Add(information);
    }
    private void Next()
    {
        currentNode = currentNode.Next;
    }
    private void Previous()
    {
        currentNode = currentNode.Prev;
    }
    private void UpdateImages()
    {
        if (currentNode == null) return;

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
}
