using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherConsumableInventory : ItemShowList
{
    [SerializeField] private List<Item> consumableList = new List<Item>();
    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private MotherConsuambeUI motherConsumableUI;

    private void OnEnable() 
    {
        MotherConsumeManager.OnConsumableConsume += ShowList;
    }

    private void OnDisable() 
    {
        MotherConsumeManager.OnConsumableConsume -= ShowList;
    }

    public override void ShowList(){
        
        RefreshList();
        foreach (Item item in consumableList){
            if(HouseInventorySystem.GetItemAmount(item) == 0) return;    
            GameObject obj = Instantiate(inventoryUI , inventoryContent);
            motherConsumableUI = obj.GetComponent<MotherConsuambeUI>();
            motherConsumableUI.SetCraftedEquipment(item);       
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
            motherConsumableUI = item.gameObject.GetComponent<MotherConsuambeUI>();
            searchedEquipment = motherConsumableUI.GetItem();
            if(cradtedItem == searchedEquipment){
                return true;
            }
        }
        return false;
    }
}
