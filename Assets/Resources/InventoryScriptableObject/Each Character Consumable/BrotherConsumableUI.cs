using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class BrotherConsumableUI : MonoBehaviour
{
    [SerializeField] public Item craftedItem;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] public TextMeshProUGUI itemAmount;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private Image itemSprite;

    public static event Action<Item> OnUseConsumable;

    private void OnEnable() {
        BrotherConsumeManager.OnConsumableConsume += UpdateAmount;
        
        HouseInventorySystem.OnValueChanged += UpdateAmount;
        HouseInventorySystem.OnItemDepleted += DestroyItem;

    }
    private void OnDisable() {
        BrotherConsumeManager.OnConsumableConsume -= UpdateAmount;

        HouseInventorySystem.OnValueChanged -= UpdateAmount;
        HouseInventorySystem.OnItemDepleted -= DestroyItem;
    }

    public void SetCraftedEquipment(Item item){
        craftedItem = item;
        SetInvetoryItem();
        SetItemType();
        UpdateAmount();
    }

    private void SetItemType()
    {
        if(craftedItem.itemType == Item.ItemType.Medicine)
        {
            itemType.text = "Use";
        }
        else if(craftedItem.itemType == Item.ItemType.Food)
        {
            itemType.text = "Eat";
        }
    }

    private void SetInvetoryItem(){
        itemName.text = craftedItem.itemName;
        itemSprite.sprite  = craftedItem.itemIcon;
        
    }

    public void UseConsumable()
    {
        OnUseConsumable?.Invoke(craftedItem);
    }

    public void UpdateAmount()
    {
        itemAmount.text = HouseInventorySystem.GetItemAmount(craftedItem).ToString();
        Debug.Log($"item amount : {HouseInventorySystem.GetItemAmount(craftedItem).ToString()}");
    }

    public Item GetItem(){
        return craftedItem;
    }

    private void DestroyItem(Item item)
    {
        if(this.craftedItem == item)
        {
            Destroy(this.gameObject);
        }

    }
}
