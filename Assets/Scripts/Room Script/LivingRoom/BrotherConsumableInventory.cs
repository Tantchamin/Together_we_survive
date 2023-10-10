using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherConsumableInventory : ItemShowList
{
    [SerializeField] private List<Item> consumableList = new List<Item>();
    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private BrotherConsumableUI brotherConsumableUI;

    private void OnEnable() 
    {
        BrotherConsumeManager.OnConsumableConsume += ShowList;
    }

    private void OnDisable() 
    {
        BrotherConsumeManager.OnConsumableConsume -= ShowList;
    }

    public override void ShowList(){
        
        RefreshList();
        foreach (Item item in consumableList){
            if(HouseInventorySystem.GetItemAmount(item) == 0) return;    
            GameObject obj = Instantiate(inventoryUI , inventoryContent);
            brotherConsumableUI = obj.GetComponent<BrotherConsumableUI>();
            brotherConsumableUI.SetCraftedEquipment(item);       
        }
    }

    public void RefreshList()
    {
        ClearList();
        FillList();
        
    }
    public override void FillList()
    {
        consumableList = HouseInventorySystem.GetConsumableItemList();
    }

    public override void ClearList()
    {
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        consumableList.Clear();
    }

    protected override bool IsItemInstantiated(Item cradtedItem){
        Item searchedEquipment = null;
        foreach(Transform item in inventoryContent){
            brotherConsumableUI = item.gameObject.GetComponent<BrotherConsumableUI>();
            searchedEquipment = brotherConsumableUI.GetItem();
            if(cradtedItem == searchedEquipment){
                return true;
            }
        }
        return false;
    }
}
