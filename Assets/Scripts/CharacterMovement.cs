using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
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
        CollectibleItemLogic item = _interactableObject.GetComponent<CollectibleItemLogic>();
        item.OnItemPicked();
        _interactableObject = null;
    }
    void OnTriggerEnter(Collider collider)
    {
        _canInteract = true;
        _interactableObject = collider;
    }
    void OnTriggerExit()
    {
        _canInteract = false;
    }
}
