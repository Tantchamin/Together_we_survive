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
    private static List<Food> houseFoodList = new List<Food>();
    private static Dictionary<Item , byte> houseFuelDic = new Dictionary<Item , byte>();
    private static List<Item> consumableList = new List<Item>();
    private static List<Item> houseInventoryListWithoutAMount = new List<Item>();
    private static Dictionary<Item , byte > inventoryDictionary = new Dictionary<Item, byte>();
    public static List<Dictionary<Item , byte >> houseInventoryList = new List<Dictionary<Item , byte >>();
    public static event Action OnValueChanged;
    public static event Action<Item> OnItemDepleted;
    public static void AddItem(Item item , byte amount){  
        if(CheckItem(item) == false){
            Dictionary<Item , byte> addedItem = new Dictionary<Item, byte>
            {
                { item, amount }
            };
            houseInventoryList.Add(addedItem);
        }else if(CheckItem(item) == true && (item.itemType == Item.ItemType.Tool || 
        item.itemType == Item.ItemType.Weapon)){
            Dictionary<Item , byte> addedEqiupment = new Dictionary<Item, byte>
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
    public static void AddFuelToFuelList(Fuel fuel)
    {
        houseFuelList.Add(fuel);
    }
    public static void AddToolToToolList(Tool tool)
    {
        houseToolList.Add(tool);
    }
    public static void AddMedicineToMedList(Medicine medicine)
    {
        houseMedList.Add(medicine);
    }
    public static void AddAmmoToAmmoList(Ammo ammo)
    {
        houseAmmoList.Add(ammo);
    }
    public static void AddFoodToFoodList(Food food)
    {
        houseFoodList.Add(food);
    }
    public static List<int> GetItemAmountList()
    {
        Item searchedItem = null;
        int searchedItemAmount = 0;
        foreach(Dictionary<Item , byte> allItem in houseInventoryList){
            foreach(KeyValuePair<Item , byte > kvp in allItem){
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                houseItemAmountList.Add(searchedItemAmount);            
            }
        }
        return houseItemAmountList;
    }
    public static List<Item> GetItemListWithOutAmount(){
        houseInventoryListWithoutAMount.Clear();
        Item searchedItem = null;
        int searchedItemAmount = 0;
        foreach(Dictionary<Item , byte> allItem in houseInventoryList){
            foreach(KeyValuePair<Item , byte > kvp in allItem){
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                houseInventoryListWithoutAMount.Add(searchedItem);            
            }
        }
        return houseInventoryListWithoutAMount;
    }
    public static List<Dictionary<Item , byte >> GetItemListWithAmount()
    {
        return houseInventoryList;
    }
    public static Dictionary<Item , byte > GetEquipmentDictionary(){
        return inventoryDictionary; 
    }

    public static List<Item> GetWeaponList()
    {
        List<Item> weaponList = new List<Item>();
        foreach(Item item in GetItemListWithOutAmount())
        {
            if(item.itemType == Item.ItemType.Weapon)
            {
                weaponList.Add(item as Weapon);
            }
        }
        return weaponList;
    }
    public static List<Item> GetToolsList()
    {
        List<Item> toolList = new List<Item>();
        foreach(Item item in GetItemListWithOutAmount())
        {
            if(item.itemType == Item.ItemType.Tool)
            {
                toolList.Add(item as Tool);
            }
        }
        return toolList;
    }
    public static Dictionary<Item,byte> GetFuelList()
    {
        foreach(Dictionary<Item , byte> allItem in houseInventoryList)
        {
            foreach(KeyValuePair<Item , byte> kvp in allItem)
        {
            if(kvp.Key.itemType == Item.ItemType.Fuel)
            {
                houseFuelDic.Add(kvp.Key , kvp.Value);
            }
        }
        }
        
        return houseFuelDic;
    }
    public static List<Medicine> GetMedicineList()
    {
        return houseMedList;
    }
    public static List<Ammo> GetAmmoList()
    {
        return houseAmmoList;
    }
    public static List<Item> GetFoodList()
    {
        List<Item> foodList = new List<Item>();
        foreach(Item item in houseInventoryListWithoutAMount)
        {
            if(item.itemType == Item.ItemType.Food)
            {
                foodList.Add(item as Food);
            }
        }
        return foodList;
    }
    public static List<Item> GetConsumableItemList()
    {
        consumableList.Clear();
        
        foreach(Item item in GetItemListWithOutAmount())
        {
            if(item.itemType == Item.ItemType.Food || item.itemType == Item.ItemType.Medicine)
            {
                consumableList.Add(item);
            }
        }
        return consumableList;
    }


    public static bool CheckItem(Item craftedItem){
        Item searchedItem;
        foreach(Dictionary<Item , byte> allItem in houseInventoryList){
            foreach(KeyValuePair<Item , byte > kvp in allItem){ 
                searchedItem = kvp.Key;
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
        foreach(Dictionary<Item,byte> equipment in houseInventoryList){
            foreach(KeyValuePair<Item , byte > kvp in equipment){        
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

        foreach(Dictionary<Item , byte> item in houseInventoryList.ToList()){
            foreach(KeyValuePair<Item , byte > kvp in item){ 
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
        foreach(Dictionary<Item , byte> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<Item , byte > kvp in allEquiptment){        
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
        foreach(Dictionary<Item,byte> equipment in houseInventoryList){
            foreach(KeyValuePair<Item , byte > kvp in equipment){        
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                if(searchedItem == craftedItem){
                    return searchedItemAmount;
                    
                }
            }
        }
        return searchedItemAmount;
    }
    public static int GetItemAmount(string craftedItem){
        Item searchedItem = null;
        string searchedItemName = "";
        int searchedItemAmount = 0;
        foreach(Dictionary<Item,byte> equipment in houseInventoryList){
            foreach(KeyValuePair<Item , byte > kvp in equipment){        
                searchedItem = kvp.Key;
                searchedItemAmount = kvp.Value;
                searchedItemName = kvp.Key.itemName;
                if(searchedItemName == craftedItem){
                    return searchedItemAmount;
                    
                }
            }
        }
        return searchedItemAmount;
    }

    public static void StackItemAmount(Item craftedItem , int amount){
        Item searchedItem = null;
        foreach(Dictionary<Item,byte> item in houseInventoryList){
            for(int index = 0 ; index < item.Count; index ++){
                KeyValuePair <Item , byte> kvp = item.ElementAt(index);
                searchedItem = kvp.Key;
                if(searchedItem == craftedItem){
                    if(item.TryGetValue(craftedItem , out byte currentAmount)){
                        item[craftedItem] = (byte)(currentAmount + amount);
                    }
                }
            }     
        }
    }

    public static void UseItem(Item usedItem , int amount)
    {
        Item searchedItem = null;
        foreach(Dictionary<Item,byte> item in houseInventoryList.ToList()){
            if(item == null) continue;
            for(int index = 0 ; index < item.Count; index ++){
                KeyValuePair <Item , byte> kvp = item.ElementAt(index);
                searchedItem = kvp.Key;
                if(searchedItem == usedItem){
                item.TryGetValue(usedItem , out byte currentAmount);
                    if(item[usedItem] > 1)
                    {
                        item[usedItem] = (byte)(currentAmount - amount);
                        Debug.Log($"amount left:{kvp.Key.name} + {item[usedItem]}");
                        OnValueChanged?.Invoke();
                        break; 
                    }
                    else if(item[usedItem] == 1)
                    {
                        item[usedItem] = (byte)(currentAmount - amount);
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
