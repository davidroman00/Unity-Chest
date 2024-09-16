using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // [SerializeField]
    // Transform _itemSlotsParent;
    // Transform[] _itemSlots;
    public List<Item> Inventory = new();
    Collider _interactableObject;

    public class Item
    {
        SpriteRenderer InventoryImage;
        public Item(SpriteRenderer img)
        {
            InventoryImage = img;
        }
        // public void AddItemOnUI()
        // {

        // }
    }
    void Awake()
    {
        //_itemSlots = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 currentPos = transform.position;
            currentPos.x += Time.deltaTime * 4;
            transform.position = new Vector3(currentPos.x, transform.position.y, currentPos.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 currentPos = transform.position;
            currentPos.x -= Time.deltaTime * 4;
            transform.position = new Vector3(currentPos.x, transform.position.y, currentPos.z);
        }
        if (Input.GetKeyDown(KeyCode.E) && _interactableObject != null)
        {
            string tag = _interactableObject.tag;
            switch (tag)
            {//lo hago con switch por si en el futuro el numero de interacciones sube más.
                case "Chest":
                    ChestInteraction();
                    break;
                case "Item":
                    ItemInteraction();
                    break;
            }
        }
    }
    void ChestInteraction()
    {
        ChestRandomAlgorithm chest = _interactableObject.GetComponentInParent<ChestRandomAlgorithm>();
        chest.OnChestOpen();
    }
    void ItemInteraction()
    {
        CollectibleItemLogic pickedItem = _interactableObject.GetComponent<CollectibleItemLogic>();
        Item newInventoryItem = new(pickedItem.Image);
        Inventory.Add(newInventoryItem);
        pickedItem.OnItemPicked();
    }
    void OnTriggerEnter(Collider collider)
    {
        _interactableObject = collider;
    }
}
