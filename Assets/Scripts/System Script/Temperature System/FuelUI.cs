using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FuelUI : MonoBehaviour
{

    [SerializeField] public Item craftedItem;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] public TextMeshProUGUI fuelAmount;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [SerializeField] private GameObject itemDescriptionPanel;
    [SerializeField] private Image itemSprite;
    public static event Action<Fuel> OnFuelUse; 
    Fuel fuel;

    public void UseFuel()
    {
        fuel = craftedItem as Fuel;
        OnFuelUse?.Invoke(fuel);
        UpdateText();
    }


    private void Start() {
        itemDescriptionPanel.SetActive(false);
    }
    public void SetCraftedEquipment(Item item){
        craftedItem = item;
        SetInvetoryItem();
        ConsumableItem();
    }

    private void OnEnable() {
        HouseInventorySystem.OnValueChanged += UpdateText;
        HouseInventorySystem.OnItemDepleted += DestroyItem;
        Furnance.OnPutFuel += UpdateText;
    }
    private void OnDisable() {
        HouseInventorySystem.OnValueChanged -= UpdateText;
        HouseInventorySystem.OnItemDepleted -= DestroyItem;

        Furnance.OnPutFuel += UpdateText;

    }

    private void SetInvetoryItem(){
        itemName.text = craftedItem.itemName;
        itemSprite.sprite  = craftedItem.itemIcon;
        itemDescription.text = craftedItem.description;
        
    }

    private void ConsumableItem(){
        if(craftedItem is Fuel || craftedItem is Medicine || craftedItem is Food){
            fuelAmount.text = HouseInventorySystem.GetItemAmount(craftedItem).ToString();   
        }
        else{
            fuelAmount.enabled = false;
        }
    }

    public virtual void UpdateText()
    {
        fuelAmount.text = HouseInventorySystem.GetItemAmount(craftedItem).ToString();
        Debug.Log($"Name of the text item {craftedItem}");
         
    }
    private void DestroyItem(Item item)
    {
        var fuelAsItem = item as Fuel;
        if(this.craftedItem == fuelAsItem)
        {
            Destroy(this.gameObject);
        }

    }
        


    public Item GetCraftedEquipment(){

        return craftedItem;
    }
}
