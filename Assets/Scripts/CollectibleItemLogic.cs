using UnityEngine;

public class CollectibleItemLogic : MonoBehaviour
{
    public SpriteRenderer img;
    public void OnItemPicked(){        
        Destroy(gameObject);
    }
}
