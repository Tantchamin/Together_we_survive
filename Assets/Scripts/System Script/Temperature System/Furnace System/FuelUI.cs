using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FuelUI : MonoBehaviour
{
    [SerializeField] public Item craftedItem;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] public TextMeshProUGUI fuelAmount;
    [SerializeField] private Button button;
    [SerializeField] private Image itemSprite;
    public static event Action<Fuel> OnFuelUse; 
    Fuel fuel;

    public void UseFuel()
    {
        fuel = craftedItem as Fuel;
        OnFuelUse?.Invoke(fuel);
        UpdateText();
    }

    public void SetItem(Item item){
        craftedItem = item;
        SetInvetoryItem();
    }
    public void SetAmount(byte amount)
    {
        fuelAmount.text = amount.ToString();
    }

    private void OnEnable() {
        CheckFurnaceButton(false);
        CheckCookStoveButton(false);
        HouseInventorySystem.OnValueChanged += UpdateText;
        HouseInventorySystem.OnItemDepleted += DestroyItem;

        Furnace.OnFurnaceSwitch += CheckFurnaceButton;
        CookStove.OnLightedSwitch += CheckCookStoveButton;

        Furnace.OnPutFuel += UpdateText;
    }
    private void OnDisable() {
        
        HouseInventorySystem.OnValueChanged -= UpdateText;
        HouseInventorySystem.OnItemDepleted -= DestroyItem;

        Furnace.OnFurnaceSwitch -= CheckFurnaceButton;
        CookStove.OnLightedSwitch -= CheckCookStoveButton;

        Furnace.OnPutFuel -= UpdateText;

    }

    private void SetInvetoryItem(){
        itemName.text = craftedItem.itemName;
        itemSprite.sprite  = craftedItem.itemSprite;
        
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
    public void CheckFurnaceButton(bool _isenabled)
    {
        if(Furnace.isIgnited == true)
        {
            button.interactable = false;
            UpdateText();
        }
        else if(Furnace.isIgnited == false)
        {
            button.interactable = true;
            UpdateText();
        }
    }

    public void CheckCookStoveButton(bool _isenabled)
    {
        if(CookStove.isIgnited == true)
        {
            button.interactable = false;
            UpdateText();
        }
        else if(CookStove.isIgnited == false)
        {
            button.interactable = true;
            UpdateText();
        }
    }
    public Item GetCraftedItem(){

        return craftedItem;
    }
}
