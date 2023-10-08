using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;


public static class HouseInventorySystem {
    private static List<Weapon> houseWeaponList = new List<Weapon>();
    private static List<Tool> houseToolList = new List<Tool>();
    private static List<Fuel> houseFuelList = new List<Fuel>();
    private static List<Ammo> houseAmmoList = new List<Ammo>();
    private static List<Medicine> houseMedList = new List<Medicine>();
    private static List<int> houseItemAmountList = new List<int>();

    private static List<Item> houseInventoryListWithoutAMount = new List<Item>();
    private static Dictionary<Item , int > inventoryDictionary = new Dictionary<Item, int>();
    public static List<Dictionary<Item , int >> houseInventoryList = new List<Dictionary<Item , int >>();
    public static event Action OnValueChanged;
    public static event Action<Item> OnItemDepleted;
    public static void AddItem(Item item , int amount){  
        if(CheckItem(item) == false){
            Dictionary<Item , int> addedEqiupment = new Dictionary<Item, int>
            {
                { item, amount }
            };
            houseInventoryList.Add(addedEqiupment);
        }else if(CheckItem(item) == true && (item.itemType == Item.ItemType.Tool || 
        item.itemType == Item.ItemType.Weapon)){
            Dictionary<Item , int> addedEqiupment = new Dictionary<Item, int>
            {
                { item, amount }
            };
            houseInventoryList.Add(addedEqiupment);
        }else if (CheckItem(item) == true && (item is Fuel || item is Medicine || item is Food)){
            Debug.Log("Stacking " + item.itemName);
            StackItemAmount(item , amount);
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
    public static void AddFuelToFuelList(Fuel fuel)
    {
        houseFuelList.Add(fuel);
    }
    public static void AddMedicineToMedList(Medicine medicine)
    {
        houseMedList.Add(medicine);
    }
    public static void AddAmmoToAmmoList(Ammo ammo)
    {
        houseAmmoList.Add(ammo);
    }
    public static List<int> GetItemAmountList()
    {
        Item searchedItem = null;
        int searchedItemAmount = 0;
        foreach(Dictionary<Item , int> allItem in houseInventoryList){
            foreach(KeyValuePair<Item , int > kvp in allItem){
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                houseItemAmountList.Add(searchedItemAmount);            
            }
        }
        return houseItemAmountList;
    }
    public static List<Item> GetItemListWithOutAmount(){
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
    public static List<Dictionary<Item , int >> GetItemListWithAmount()
    {
        return houseInventoryList;
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
    public static List<Fuel> GetFuelList()
    {
        return houseFuelList;
    }
    public static List<Medicine> GetMedicineList()
    {
        return houseMedList;
    }
    public static List<Ammo> GetAmmoList()
    {
        return houseAmmoList;
    }

    public static bool CheckItem(Item craftedItem){
        Item searchedItem;
        foreach(Dictionary<Item , int> allItem in houseInventoryList){
            foreach(KeyValuePair<Item , int > kvp in allItem){ 
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
     public static bool CheckItem(string itemName){
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

    public static void RemoveEquipment(Item removeItem){
        Item searchedItem = null;
        int searchedItemAmount = 0;

        foreach(Dictionary<Item , int> item in houseInventoryList.ToList()){
            foreach(KeyValuePair<Item , int > kvp in item){ 
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                if(removeItem == searchedItem){
                    houseInventoryList.Remove(item);
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

   

    public static int GetItemAmount(Item craftedItem){
        Item searchedItem = null;
        int searchedItemAmount = 0;
        foreach(Dictionary<Item,int> equipment in houseInventoryList){
            foreach(KeyValuePair<Item , int > kvp in equipment){        
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                if(searchedItem == craftedItem){
                    return searchedItemAmount;
                    
                }
            }
        }
        return searchedItemAmount;
    }

    public static void StackItemAmount(Item craftedItem , int amount){
        Item searchedItem = null;
        foreach(Dictionary<Item,int> item in houseInventoryList){
            for(int index = 0 ; index < item.Count; index ++){
                KeyValuePair <Item , int> kvp = item.ElementAt(index);
                searchedItem = kvp.Key;
                if(searchedItem == craftedItem){
                    if(item.TryGetValue(craftedItem , out int currentAmount)){
                        item[craftedItem] = currentAmount + amount;
                    }
                }
            }     
        }
    }

    public static void UseItem(Item usedItem , int amount)
    {
        Item searchedItem = null;
        foreach(Dictionary<Item,int> item in houseInventoryList.ToList()){
            if(item == null) continue;
            for(int index = 0 ; index < item.Count; index ++){
                KeyValuePair <Item , int> kvp = item.ElementAt(index);
                searchedItem = kvp.Key;
                if(searchedItem == usedItem){
                item.TryGetValue(usedItem , out int currentAmount);
                    if(item[usedItem] > 1)
                    {
                        item[usedItem] = currentAmount - amount;
                        Debug.Log($"amount left:{kvp.Key.name} + {item[usedItem]}");
                        OnValueChanged?.Invoke();
                        break; 
                    }
                    else if(item[usedItem] == 1)
                    {
                        item[usedItem] = currentAmount - amount;
                        Debug.Log($"remove {usedItem}");
                        RemoveEquipment(usedItem);
                        OnValueChanged?.Invoke();
                        OnItemDepleted?.Invoke(searchedItem);
                        break;
                    }
                                     
                                         
                    
                }
            }     
        }
    }


    public static Item RandomItem()
    {
        float totalWeight = 0;
        float value = UnityEngine.Random.value * totalWeight;
        return null;
    }
}
