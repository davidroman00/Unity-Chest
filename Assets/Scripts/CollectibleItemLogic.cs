
using UnityEngine;

public class CollectibleItemLogic : MonoBehaviour
{
    [SerializeField]
    
    public void OnItemPicked(){
        Destroy(this.gameObject);
    }
}
