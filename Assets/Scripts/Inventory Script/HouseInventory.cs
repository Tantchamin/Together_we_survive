using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Search;
using System.Linq;

public static class HouseInventory {

    // public static List<Equipment> houseInventory = new List<Equipment>();
    // [SerializeField] private Equipment equipmentData;



    private static Dictionary<Equipment , int > inventoryDictionary = new Dictionary<Equipment, int>();
    public static List<Dictionary<Equipment , int >> houseInventory = new List<Dictionary<Equipment , int >>();
    public static void AddInventory(Equipment equipment , int amount){  
        Dictionary<Equipment , int> addedEqiupment = new Dictionary<Equipment, int>();
        addedEqiupment.Add(equipment , amount);
        houseInventory.Add(addedEqiupment);
    }

    public static Equipment GetEquipment(int equipmentID){
        Equipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        int searchedEqipmentID = 0;
        foreach(Dictionary<Equipment , int> allEquiptment in houseInventory){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                searchedEqipmentID = searchedEquipment.equipmentID;
                if(equipmentID == searchedEqipmentID){
                    break;
                }
                else
                    return null;
            }
        }

        return searchedEquipment;
    }

    public static void RemoveFromInventory(int equipmentID){
        Equipment searchedEquipment = null;
        int searchedEqipmentAmount = 0;
        int searchedEqipmentID = -1;

        foreach(Dictionary<Equipment , int> allEquiptment in houseInventory.ToList()){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){ 
                searchedEquipment = kvp.Key;
                searchedEqipmentAmount = kvp.Value;
                searchedEqipmentID = searchedEquipment.equipmentID;
                if(equipmentID == searchedEqipmentID){
                    houseInventory.Remove(allEquiptment);
                    break;
                }
            }
        }
    }

    public static void PrintInventory(){
        Equipment searchedEquipment = null;
        foreach(Dictionary<Equipment , int> allEquiptment in houseInventory){
            foreach(KeyValuePair<Equipment , int > kvp in allEquiptment){        
                searchedEquipment = kvp.Key;
                Debug.Log(searchedEquipment.equiptmentName.ToString());
            }
    
        }
    }

}
