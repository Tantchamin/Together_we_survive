using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftUI : MonoBehaviour
{
    
    [SerializeField] private Item craftedItem;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [SerializeField] private Image itemSprite;


    void Start()
    {
        itemName.text = craftedItem.itemName;
        itemDescription.text = craftedItem.description;
        itemSprite.sprite  = craftedItem.itemIcon;
    }

    public Item GetCraftedItem(){
        return craftedItem;
    }
}
