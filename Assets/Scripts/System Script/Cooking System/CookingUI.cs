using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingUI : ItemShowList
{
    [SerializeField] private List<Item> houseFoodList = new List<Item>();
    [SerializeField] private List<Item> houseItemList = new List<Item>();

    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private InventoryUI inventoryUIscript;

    public override void  ShowList(){
        RefreshList();
        foreach (Item item in houseFoodList){
            if(HouseInventorySystem.GetItemAmount(item) == 0) return;    
            if(IsItemInstantiated(item) == true ) return;
            GameObject obj = Instantiate(inventoryUI , inventoryContent);
            inventoryUIscript = obj.GetComponent<InventoryUI>();
            inventoryUIscript.SetCraftedEquipment(item);       
            
        }
    }
    public override void ClearList(){
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        houseFoodList.Clear();
        houseItemList.Clear();
        
    }

    public void RefreshList()
    {
        ClearList();
        FillList();
    }

    public override void FillList()
    {
        houseItemList = HouseInventorySystem.GetItemListWithOutAmount();
        foreach(Item item in houseItemList)
        {
            if(item.itemType == Item.ItemType.Food && houseFoodList.Contains(item) == false)
            {
                houseFoodList.Add(item);
            }
            
        }
    }

    protected override bool IsItemInstantiated(Item cradtedItem){
        Item searchedEquipment = null;
        foreach(Transform item in inventoryContent){
            inventoryUIscript = item.gameObject.GetComponent<InventoryUI>();
            searchedEquipment = inventoryUIscript.GetCraftedEquipment();
            if(cradtedItem == searchedEquipment){
                return true;
            }
        }
        return false;
    }
}
