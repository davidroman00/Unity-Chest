using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    bool _canInteract;
    ChestRandomAlgorithm _interactableObject;
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
        if (Input.GetKeyDown(KeyCode.E) && !_interactableObject.IsOpened && _canInteract)
        {
            _interactableObject.OnChestOpen();
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        _canInteract = true;
        _interactableObject = collider.GetComponent<ChestRandomAlgorithm>();
    }
    void OnTriggerExit()
    {
        _canInteract = false;
    }
}
