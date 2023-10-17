using UnityEngine.UI;
using UnityEngine;
using TMPro;

public abstract class NightItemSelectUI : MonoBehaviour
{
    [SerializeField] protected Item item;
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected Image itemSprite; 
    protected abstract void SetItem(Item item);

}
