using UnityEngine;
using UnityEngine.UI;

public class CollectibleItemLogic : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer img;
    public void OnItemPicked(){
        Destroy(gameObject);
    }
}
