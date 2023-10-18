using System;
using System.Collections.Generic;
using UnityEngine;

public class CookStoveFuel : ItemShowList
{

    [SerializeField] protected GameObject fuelUI;
    [SerializeField] protected Transform inventoryContent;
    [SerializeField] protected Dictionary<Item,byte> fuelDic = new Dictionary<Item,byte>();
    [SerializeField] protected List<int> itemAmountList = new List<int>();
    protected FuelUI fuelUIScript;
    public static event Action OnStoveListShow , OnStoveListUnShow;

    public override void ShowList()
    {
        RefreshList();
        OnStoveListShow?.Invoke();
        foreach(KeyValuePair<Item , byte> kvp in fuelDic)
        {
            GameObject obj = Instantiate(fuelUI , inventoryContent);
            fuelUIScript = obj.GetComponent<FuelUI>();
            fuelUIScript.SetItem(kvp.Key);  
            fuelUIScript.SetAmount(kvp.Value);
        }
    }
    public void RefreshList()
    {
        ClearList();
        FillList();
    }
    public override void FillList()
    {
        fuelDic = HouseInventorySystem.GetFuelList();
        itemAmountList = HouseInventorySystem.GetItemAmountList();
    }
    public override void ClearList(){
        OnStoveListUnShow?.Invoke();
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        fuelDic.Clear();
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
