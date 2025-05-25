using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]private Image[] image;
    [SerializeField] private ItemsInformation[] itemInformation;
    [SerializeField] private Transform tarjet;
    private CircularDoubleLinkedList<ItemsInformation> listaCircular = new CircularDoubleLinkedList<ItemsInformation>();
    private Node<ItemsInformation> currentNode;

    private void Start()
    {
        for (int i = 0; i < itemInformation.Length; i++)
        {
            listaCircular.Add(itemInformation[i]);
            itemInformation[i].ItemTranform.position = tarjet.position;
            itemInformation[i].ItemTranform.SetParent(tarjet);
            itemInformation[i].UpdateRotation();
        }
        currentNode = new Node<ItemsInformation>(itemInformation[0]);
        UpdateImages();
    }
    public void Add(ItemsInformation information)
    {
        listaCircular.Add(information);
        information.ItemTranform.position = tarjet.position;
        information.ItemTranform.SetParent(tarjet);
        information.UpdateRotation();
        UpdateImages();
    }
    private void Next()
    {
        currentNode = currentNode.Next;
        UpdateImages();
    }
    private void Previous()
    {
        currentNode = currentNode.Prev;
        UpdateImages();
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
    public void GetInputScroll(Vector2 valorInput)
    {
        if(valorInput.y < 0)
        {
            Previous();
        }else if(valorInput.y > 0)
        {
            Next();
        }
    }
    private void OnEnable()
    {
        InputReader.OnScroll += GetInputScroll;
    }
    private void OnDisable()
    {
        InputReader.OnScroll -= GetInputScroll;
    }

}
