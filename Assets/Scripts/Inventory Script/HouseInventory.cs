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
    private static List<Equipment> houseInventoryListWithoutAMount = new List<Equipment>();
    private static Dictionary<Equipment , int > inventoryDictionary = new Dictionary<Equipment, int>();
    public static List<Dictionary<Equipment , int >> houseInventoryList = new List<Dictionary<Equipment , int >>();
    public static void AddEquipment(Equipment equipment , int amount){  
        if(CheckEquipment(equipment) == false){
            Dictionary<Equipment , int> addedEqiupment = new Dictionary<Equipment, int>
            {
                { equipment, amount }
            };
            houseInventoryList.Add(addedEqiupment);
        }else if(CheckEquipment(equipment) == true && (equipment.itemType == Equipment.ItemType.Tool || 
        equipment.itemType == Equipment.ItemType.Weapon)){
            Dictionary<Equipment , int> addedEqiupment = new Dictionary<Equipment, int>
            {
                { equipment, amount }
            };
            houseInventoryList.Add(addedEqiupment);
        }else if (CheckEquipment(equipment) == true && equipment.itemType == Equipment.ItemType.Consumable){
            Debug.Log("Stacking " + equipment.equipmentName);
            StackEquipmentAmount(equipment , amount);
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

    public static List<Equipment> GetEquipmentListWithOutAMount(){
        Equipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        foreach(Dictionary<Equipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                houseInventoryListWithoutAMount.Add(searchedEquipment);            
            }
        }
        return houseInventoryListWithoutAMount;
    }

    public static Dictionary<Equipment , int > GetEquipmentDictionary(){
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

    public static bool CheckEquipment(Equipment craftedEquipment){
        Equipment searchedEquipment;
        foreach(Dictionary<Equipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){ 
                searchedEquipment = kvp.Key;
                Debug.Log(craftedEquipment.equipmentName);
                Debug.Log(searchedEquipment.equipmentName);
                if(craftedEquipment == searchedEquipment){
                    return true;
                }     
            }
        }
        return false;
    }

     public static bool CheckEquipment(string equipmentName){
        string searchedEquipmentName = null;
        Equipment searchedEquipment = null;
        foreach(Dictionary<Equipment,int> equipment in houseInventoryList){
            foreach(KeyValuePair<Equipment , int > kvp in equipment){        
                searchedEquipment = kvp.Key;
                searchedEquipmentName = searchedEquipment.equipmentName;
                if(searchedEquipmentName == equipmentName){
                    return true;
                }
            }
            
        }
        return false;
    }

    public static void RemoveEquipment(int equipmentID){
        Equipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        int searchedEqipmentID = -1;

        foreach(Dictionary<Equipment , int> allEquiptment in houseInventoryList.ToList()){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){ 
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                searchedEqipmentID = searchedEquipment.ID;
                if(equipmentID == searchedEqipmentID){
                    houseInventoryList.Remove(allEquiptment);
                    break;
                }       
            }
        }
    }

    public static void PrintInventory(){
        Equipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        Debug.Log("_____________________________________________________________________");
        foreach(Dictionary<Equipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){        
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                Debug.Log($"{searchedEquipment.equipmentName} : {searchedEqipmentAmount}");
            }
        }
        Debug.Log("_____________________________________________________________________");
    }

   

    public static int GetEquipmentAmount(Equipment craftedEquipment){
        Equipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        int equipmentAmount =0;
        foreach(Dictionary<Equipment,int> equipment in houseInventoryList){
            foreach(KeyValuePair<Equipment , int > kvp in equipment){        
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                if(searchedEquipment == craftedEquipment){
                    return equipmentAmount = searchedEqipmentAmount;
                }
            }
        }
        return equipmentAmount;
    }

    public static void StackEquipmentAmount(Equipment craftedEquipment , int amount){
        Equipment searchedEquipment = null;
        foreach(Dictionary<Equipment,int> equipment in houseInventoryList){
            for(int index = 0 ; index < equipment.Count; index ++){
                KeyValuePair <Equipment , int> kvp = equipment.ElementAt(index);
                searchedEquipment = kvp.Key;
                if(searchedEquipment == craftedEquipment){
                    Debug.Log(searchedEquipment.equipmentName + "stacked");
                    if(equipment.TryGetValue(craftedEquipment , out int currentAmount)){
                        equipment[craftedEquipment] = currentAmount + amount;
                    }
                }
            }
            
        }
    }

    public static Equipment RandomEquipment()
    {
        float totalWeight = 0;
        float value = UnityEngine.Random.value * totalWeight;


        return null;
    }


}

// public static class Extensions{
//     public static void Increment<T>(this Dictionary<T,int> dict , T key , int amount){
//         int count;
//         dict.TryGetValue(key, out count);
//         dict[key] = count + amount;
//     }
// }
