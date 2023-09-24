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



    private static Dictionary<Equipment , int > inventoryDictionary = new Dictionary<Equipment, int>();
    public static List<Dictionary<Equipment , int >> houseInventoryList = new List<Dictionary<Equipment , int >>();
    public static void AddEquipment(Equipment equipment , int amount){  
        Dictionary<Equipment , int> addedEqiupment = new Dictionary<Equipment, int>();
        addedEqiupment.Add(equipment , amount);
        houseInventoryList.Add(addedEqiupment);
    }

    public static Equipment GetEquipment(int equipmentID){
        Equipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        int searchedEqipmentID = 0;
        foreach(Dictionary<Equipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                searchedEqipmentID = searchedEquipment. ID;
                if(equipmentID == searchedEqipmentID){
                    break;
                }
                else
                    return null; 
            }
        }

        return searchedEquipment;
    }

    public static bool CompareEquipment(int equipmentID){
        Equipment searchedEquipment;
        int searchedEqipmentID = 0;

        foreach(Dictionary<Equipment , int> allEquiptment in houseInventoryList.ToList()){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){ 
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
        foreach(Dictionary<Equipment , int> allEquiptment in houseInventoryList){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){        
                searchedEquipment = kvp.Key;
                Debug.Log(searchedEquipment.equipmentName.ToString());
            }
    
        }
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
            return false;
            }
            
        }
        return false;
    }

}
