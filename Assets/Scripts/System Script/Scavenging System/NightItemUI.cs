using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NightItemUI  : MonoBehaviour
{
    
    [SerializeField] private Item scravengedItem;
    [SerializeField] private TextMeshProUGUI itemAmount;
    [SerializeField] private Image itemSprite;

    public Item GetItem(){
        return scravengedItem;
    }
    public void SetItem(Item item , byte value)
    {
        scravengedItem = item;
        itemSprite.sprite = item.itemIcon;
        itemAmount.text = value.ToString();
    }
    
}