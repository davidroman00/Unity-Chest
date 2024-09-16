using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public class Item
    {
        SpriteRenderer img;
        public Item(SpriteRenderer image)
        {
            img = image;
        }
    }
    public List<Item> Inventory = new();
    bool _canInteract;
    Collider _interactableObject;
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
        if (Input.GetKeyDown(KeyCode.E) && _canInteract)
        {
            string tag = _interactableObject.tag;
            switch (tag)
            {
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
        _interactableObject = null;
    }
    void ItemInteraction()
    {
        CollectibleItemLogic pickedItem = _interactableObject.GetComponent<CollectibleItemLogic>();
        Item newInventoryItem = new(pickedItem.img);
        Inventory.Add(newInventoryItem);
        pickedItem.OnItemPicked();
        _interactableObject = null;
        Debug.Log(Inventory);
    }
    void OnTriggerEnter(Collider collider)
    {
        _canInteract = true;
        _interactableObject = collider;
        Debug.Log(collider);
    }
    void OnTriggerExit()
    {
        _canInteract = false;
        _interactableObject = null;
        Debug.Log(_interactableObject);
    }
}
