using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Search;
using System.Linq;
using System.Security.Cryptography;

public static class HouseInventorySystem {

    // public static List<Equipment> houseInventory = new List<Equipment>();
    // [SerializeField] private Equipment equipmentData;


    private static List<CraftedEquipment> houseInventoryListWithoutAMount = new List<CraftedEquipment>();
    private static Dictionary<CraftedEquipment , int > inventoryDictionary = new Dictionary<CraftedEquipment, int>();
    public static List<Dictionary<CraftedEquipment , int >> houseInventoryList = new List<Dictionary<CraftedEquipment , int >>();
    public static void AddEquipment(CraftedEquipment equipment , int amount){  
        if(CheckEquipment(equipment) == false){
            Dictionary<CraftedEquipment , int> addedEqiupment = new Dictionary<CraftedEquipment, int>
            {
                { equipment, amount }
            };
            houseInventoryList.Add(addedEqiupment);
        }else if(CheckEquipment(equipment) == true && (equipment.itemType == Equipment.ItemType.Tool || 
        equipment.itemType == Equipment.ItemType.Weapon)){
            Dictionary<CraftedEquipment , int> addedEqiupment = new Dictionary<CraftedEquipment, int>
            {
                { equipment, amount }
            };
            houseInventoryList.Add(addedEqiupment);
        }else if (CheckEquipment(equipment) == true && equipment.itemType == Equipment.ItemType.Consumable){
            Debug.Log("Stacking " + equipment.equipmentName);
            StackEquipmentAmount(equipment , amount);
        }
        
    }

    public static List<CraftedEquipment> GetEquipmentListWithOutAMount(){
        CraftedEquipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        foreach(Dictionary<CraftedEquipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<CraftedEquipment , int > kvp in allEquiptment){
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                houseInventoryListWithoutAMount.Add(searchedEquipment);            
            }
        }
        return houseInventoryListWithoutAMount;
    }

    public static Dictionary<CraftedEquipment , int > GetEquipmentDictionary(){
        return inventoryDictionary;
    }

    public static bool CheckEquipment(CraftedEquipment craftedEquipment){
        CraftedEquipment searchedEquipment;
        foreach(Dictionary<CraftedEquipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<CraftedEquipment , int > kvp in allEquiptment){ 
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
        CraftedEquipment searchedEquipment = null;
        foreach(Dictionary<CraftedEquipment,int> equipment in houseInventoryList){
            foreach(KeyValuePair<CraftedEquipment , int > kvp in equipment){        
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
        CraftedEquipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        int searchedEqipmentID = -1;

        foreach(Dictionary<CraftedEquipment , int> allEquiptment in houseInventoryList.ToList()){
            foreach(KeyValuePair<CraftedEquipment , int > kvp in allEquiptment){ 
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
        CraftedEquipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        Debug.Log("_____________________________________________________________________");
        foreach(Dictionary<CraftedEquipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<CraftedEquipment , int > kvp in allEquiptment){        
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                Debug.Log($"{searchedEquipment.equipmentName} : {searchedEqipmentAmount}");
            }
        }
        Debug.Log("_____________________________________________________________________");
    }

   

    public static int GetEquipmentAmount(CraftedEquipment craftedEquipment){
        CraftedEquipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        int equipmentAmount =0;
        foreach(Dictionary<CraftedEquipment,int> equipment in houseInventoryList){
            foreach(KeyValuePair<CraftedEquipment , int > kvp in equipment){        
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                if(searchedEquipment == craftedEquipment){
                    return equipmentAmount = searchedEqipmentAmount;
                }
            }
        }
        return equipmentAmount;
    }

    public static void StackEquipmentAmount(CraftedEquipment craftedEquipment , int amount){
        CraftedEquipment searchedEquipment = null;
        foreach(Dictionary<CraftedEquipment,int> equipment in houseInventoryList){
            for(int index = 0 ; index < equipment.Count; index ++){
                KeyValuePair <CraftedEquipment , int> kvp = equipment.ElementAt(index);
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


}

// public static class Extensions{
//     public static void Increment<T>(this Dictionary<T,int> dict , T key , int amount){
//         int count;
//         dict.TryGetValue(key, out count);
//         dict[key] = count + amount;
//     }
// }
