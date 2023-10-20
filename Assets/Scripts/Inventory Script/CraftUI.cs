using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftUI : MonoBehaviour
{
    
    [SerializeField] private CraftedItem craftedItem;

    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCrafingRecipe;

    [SerializeField] private Image itemSprite;


    void Start()
    {
        itemName.text = craftedItem.itemName;
        itemCrafingRecipe.text = craftedItem.CraftRecipe();
        itemSprite.sprite  = craftedItem.itemSprite;
    }

    public Item GetCraftedItem(){
        return craftedItem;
    }
}
