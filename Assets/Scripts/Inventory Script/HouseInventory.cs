using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Search;
using System.Linq;

public static class HouseInventorySystem {

    // public static List<Equipment> houseInventory = new List<Equipment>();
    // [SerializeField] private Equipment equipmentData;


    private static List<CraftedEquipment> houseInventoryListWithoutAMount = new List<CraftedEquipment>();
    private static Dictionary<CraftedEquipment , int > inventoryDictionary = new Dictionary<CraftedEquipment, int>();
    public static List<Dictionary<CraftedEquipment , int >> houseInventoryList = new List<Dictionary<CraftedEquipment , int >>();
    public static void AddEquipment(CraftedEquipment equipment , int amount){  
        Dictionary<CraftedEquipment , int> addedEqiupment = new Dictionary<CraftedEquipment, int>();
        addedEqiupment.Add(equipment , amount);
        houseInventoryList.Add(addedEqiupment);
    }

    public static List<CraftedEquipment> GetEquipmentList(){
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

    public static bool CompareEquipment(int equipmentID){
        CraftedEquipment searchedEquipment;
        int searchedEqipmentID = 0;

        foreach(Dictionary<CraftedEquipment , int> allEquiptment in houseInventoryList.ToList()){
            foreach(KeyValuePair<CraftedEquipment , int > kvp in allEquiptment){ 
                searchedEquipment = kvp.Key;
                searchedEqipmentID = searchedEquipment.ID;
                if(equipmentID == searchedEqipmentID){
                    return true;
                }
                else
                    return false;       
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
        foreach(Dictionary<CraftedEquipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<CraftedEquipment , int > kvp in allEquiptment){        
                searchedEquipment = kvp.Key;
                Debug.Log(searchedEquipment.equipmentName.ToString());
            }
    
        }
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
            return false;
            }
            
        }
        return false;
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
}
