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
        currentNode = listaCircular.Head;
        UpdateImages();
    }
    public void Add(ItemsInformation information)
    {
        listaCircular.Add(information);
        information.ItemTranform.position = tarjet.position;
        information.ItemTranform.SetParent(tarjet);
        information.UpdateRotation();
        information.ItemTranform.gameObject.SetActive(false);
        UpdateImages();
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
        Node<ItemsInformation> tempNode = currentNode;
        for (int i = 0; i < image.Length; i++)
        {
            if (tempNode != currentNode)
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
        if (valorInput < 0)
        {
            Previous();
        }else if(valorInput > 0)
        {
            Next();
        }
        currentNode.Value.ItemTranform.gameObject.SetActive(true);
        UpdateImages();
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
