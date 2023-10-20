using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NightItemUI  : MonoBehaviour
{
    
    [SerializeField] private Item scavengedItem;
    [SerializeField] private TextMeshProUGUI itemAmount;
    [SerializeField] private Image itemSprite;

    public Item GetItem(){
        return scavengedItem;
    }
    public void SetItem(Item item , byte value)
    {
        scavengedItem = item;
        itemSprite.sprite = item.itemSprite;
        itemAmount.text = value.ToString();
    }
    
}