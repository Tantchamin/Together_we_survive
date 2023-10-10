using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatherConsumableInventory : ItemShowList
{
    [SerializeField] private List<Item> consumableList = new List<Item>();
    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private FatherConsumableUI fatherConsumableUI;

    private void OnEnable() 
    {
        FatherConsumeManager.OnConsumableConsume += ShowList;
    }

    private void OnDisable() 
    {
        FatherConsumeManager.OnConsumableConsume -= ShowList;
    }

    public override void ShowList(){
        
        RefreshList();
        foreach (Item item in consumableList){
            if(HouseInventorySystem.GetItemAmount(item) == 0) return;    
            GameObject obj = Instantiate(inventoryUI , inventoryContent);
            fatherConsumableUI = obj.GetComponent<FatherConsumableUI>();
            fatherConsumableUI.SetCraftedEquipment(item);       
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
            fatherConsumableUI = item.gameObject.GetComponent<FatherConsumableUI>();
            searchedEquipment = fatherConsumableUI.GetItem();
            if(cradtedItem == searchedEquipment){
                return true;
            }
        }
        return false;
    }


}
