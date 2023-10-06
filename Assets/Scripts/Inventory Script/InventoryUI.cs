using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Item craftedItem;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemAmount;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [SerializeField] private GameObject itemDescriptionPanel;
    [SerializeField] private Image itemSprite;


    private void Start() {
        itemDescriptionPanel.SetActive(false);
    }
    public void SetCraftedEquipment(Item item){
        craftedItem = item;
        SetInvetoryItem();
        ConsumableItem();
    }

    private void SetInvetoryItem(){
        itemName.text = craftedItem.itemName;
        itemSprite.sprite  = craftedItem.itemIcon;
        itemDescription.text = craftedItem.description;
        
    }

    private void ConsumableItem(){
        if(craftedItem.itemType == Item.ItemType.Consumable){
            itemAmount.text = HouseInventorySystem.GetEquipmentAmount(craftedItem).ToString();   
        }
        else{
            itemAmount.enabled = false;
        }
    }

    public void UpdateText(){
        itemAmount.text = HouseInventorySystem.GetEquipmentAmount(craftedItem).ToString();   
    }

    public Item GetCraftedEquipment(){
        return craftedItem;
    }

    

}
