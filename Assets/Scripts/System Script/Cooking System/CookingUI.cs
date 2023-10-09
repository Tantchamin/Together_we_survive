using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingUI : MonoBehaviour
{
    [SerializeField] private List<Item> houseFoodList = new List<Item>();
    [SerializeField] private List<Item> houseItemList = new List<Item>();

    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private InventoryUI inventoryUIscript;

    public void ShowList(){

        FillList();
        foreach (Item item in houseFoodList){
            if(HouseInventorySystem.GetItemAmount(item) == 0) return;    
            GameObject obj = Instantiate(inventoryUI , inventoryContent);
            inventoryUIscript = obj.GetComponent<InventoryUI>();
            inventoryUIscript.SetCraftedEquipment(item);       
            
        }
    }
    public void ClearList(){
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        houseFoodList.Clear();
        houseItemList.Clear();
        
    }

    private void FillList()
    {
        houseItemList = HouseInventorySystem.GetItemListWithOutAmount();
        foreach(Item item in houseItemList)
        {
            if(item.itemType == Item.ItemType.Food)
            {
                houseFoodList.Add(item);
            }
            
        }
    }

    private bool IsItemInstantiated(Item cradtedItem){
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
