using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;


public static class HouseInventorySystem {
    private static List<Weapon> houseWeaponList = new List<Weapon>();
    private static List<Tool> houseToolList = new List<Tool>();

    // houseWeaponList.Cast<CraftedEquipment>().ToList() + 
    // houseToolList.Cast<CraftedEquipment>().ToList();
    private static List<Item> houseInventoryListWithoutAMount = new List<Item>();
    private static Dictionary<Item , int > inventoryDictionary = new Dictionary<Item, int>();
    public static List<Dictionary<Item , int >> houseInventoryList = new List<Dictionary<Item , int >>();
    public static void AddEquipment(Item item , int amount){  
        if(CheckEquipment(item) == false){
            Dictionary<Item , int> addedEqiupment = new Dictionary<Item, int>
            {
                { item, amount }
            };
            houseInventoryList.Add(addedEqiupment);
        }else if(CheckEquipment(item) == true && (item.itemType == Item.ItemType.Tool || 
        item.itemType == Item.ItemType.Weapon)){
            Dictionary<Item , int> addedEqiupment = new Dictionary<Item, int>
            {
                { item, amount }
            };
            houseInventoryList.Add(addedEqiupment);
        }else if (CheckEquipment(item) == true && item.itemType == Item.ItemType.Consumable){
            Debug.Log("Stacking " + item.itemName);
            StackEquipmentAmount(item , amount);
        }   
    }
    public static void AddWeaponToWeaponList(Weapon weapon)
    {
        houseWeaponList.Add(weapon);
    }

    public static void AddToolToToolList(Tool tool)
    {
        houseToolList.Add(tool);
    }
    public static List<Item> GetEquipmentListWithOutAMount(){
        Item searchedItem = null;
        int searchedItemAmount = 0;
        foreach(Dictionary<Item , int> allItem in houseInventoryList){
            foreach(KeyValuePair<Item , int > kvp in allItem){
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                houseInventoryListWithoutAMount.Add(searchedItem);            
            }
        }
        return houseInventoryListWithoutAMount;
    }

    public static Dictionary<Item , int > GetEquipmentDictionary(){
        return inventoryDictionary;
    }

    public static List<Weapon> GetWeaponList()
    {
        return houseWeaponList;
    }

    public static List<Tool> GetToolsList()
    {
        return houseToolList;
    }

    public static bool CheckEquipment(Item craftedItem){
        Item searchedItem;
        foreach(Dictionary<Item , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<Item , int > kvp in allEquiptment){ 
                searchedItem = kvp.Key;
                Debug.Log(craftedItem.itemName);
                Debug.Log(searchedItem.itemName);
                if(craftedItem == searchedItem){
                    return true;
                }     
            }
        }
        return false;
    }
     public static bool CheckEquipment(string itemName){
        string searchedItemName = null;
        Item searchedItem = null;
        foreach(Dictionary<Item,int> equipment in houseInventoryList){
            foreach(KeyValuePair<Item , int > kvp in equipment){        
                searchedItem = kvp.Key;
                searchedItemName = searchedItem.itemName;
                if(searchedItemName == itemName){
                    return true;
                }
            }
        }
        return false;
    }

    public static void RemoveEquipment(int itemID){
        Item searchedItem = null;
        int searchedItemAmount = 0;
        int searchedItemID = -1;

        foreach(Dictionary<Item , int> allItem in houseInventoryList.ToList()){
            foreach(KeyValuePair<Item , int > kvp in allItem){ 
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                searchedItemID = searchedItem.ID;
                if(itemID == searchedItemID){
                    houseInventoryList.Remove(allItem);
                    break;
                }       
            }
        }
    }

    public static void PrintInventory(){
        Item searchedItem = null;
        int searchedItemAmount = 0;
        Debug.Log("_____________________________________________________________________");
        foreach(Dictionary<Item , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<Item , int > kvp in allEquiptment){        
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                Debug.Log($"{searchedItem.itemName} : {searchedItemAmount}");
            }
        }
        Debug.Log("_____________________________________________________________________");
    }

   

    public static int GetEquipmentAmount(Item craftedItem){
        Item searchedItem = null;
        int searchedItemAmount = 0;
        int itemAmount =0;
        foreach(Dictionary<Item,int> equipment in houseInventoryList){
            foreach(KeyValuePair<Item , int > kvp in equipment){        
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                if(searchedItem == craftedItem){
                    return itemAmount = searchedItemAmount;
                }
            }
        }
        return itemAmount;
    }

    public static void StackEquipmentAmount(Item craftedItem , int amount){
        Item searchedItem = null;
        foreach(Dictionary<Item,int> equipment in houseInventoryList){
            for(int index = 0 ; index < equipment.Count; index ++){
                KeyValuePair <Item , int> kvp = equipment.ElementAt(index);
                searchedItem = kvp.Key;
                if(searchedItem == craftedItem){
                    Debug.Log(searchedItem.itemName + "stacked");
                    if(equipment.TryGetValue(craftedItem , out int currentAmount)){
                        equipment[craftedItem] = currentAmount + amount;
                    }
                }
            }     
        }
    }

    public static Item RandomEquipment()
    {
        float totalWeight = 0;
        float value = UnityEngine.Random.value * totalWeight;
        return null;
    }
}
