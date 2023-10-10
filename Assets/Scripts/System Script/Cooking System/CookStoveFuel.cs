using System;
using System.Collections.Generic;
using UnityEngine;

public class CookStoveFuel : ItemShowList
{

    [SerializeField] protected GameObject fuelUI;
    [SerializeField] protected Transform inventoryContent;
    [SerializeField] protected List<Item> itemList = new List<Item>();
    [SerializeField] protected List<int> itemAmountList = new List<int>();
    protected FuelUI fuelUIScript;
    public static event Action OnStoveListShow , OnStoveListUnShow;

    public override void ShowList()
    {
        RefreshList();
        OnStoveListShow?.Invoke();
        foreach(Item item in itemList)
        {
            if(item is Fuel)
            {
                GameObject obj = Instantiate(fuelUI , inventoryContent);
                fuelUIScript = obj.GetComponent<FuelUI>();
                fuelUIScript.SetCraftedEquipment(item);  
            }
        }
    }
    public void RefreshList()
    {
        ClearList();
        FillList();
    }
    public override void FillList()
    {
       itemList = HouseInventorySystem.GetItemListWithOutAmount();
        itemAmountList = HouseInventorySystem.GetItemAmountList();
    }
    public override void ClearList(){
        OnStoveListUnShow?.Invoke();
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        itemList.Clear();
        itemAmountList.Clear();
    }
    protected override bool IsItemInstantiated(Item fuel){
        Item searchedItem = null;
        foreach(Transform item in inventoryContent){
            fuelUIScript = item.gameObject.GetComponent<FuelUI>();
            searchedItem = fuelUIScript.GetCraftedItem();
            if(fuel == searchedItem){
                return true;
            }
        }
        return false;
    }
}
