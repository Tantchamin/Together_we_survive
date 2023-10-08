using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceFuel : MonoBehaviour
{
    [SerializeField] private GameObject fuelUI;
    [SerializeField] private Transform inventoryContent;
    private FuelUI fuelUIScript;
    [SerializeField]  List<Item> itemList = new List<Item>();
    [SerializeField] List<int> itemAmountList = new List<int>();
    public static event Action OnShowList;

    public void ShowList()
    {
        // foreach(Dictionary<Item , int> allItem in HouseInventorySystem.houseInventoryList)
        // {   
        //     foreach(KeyValuePair<Item , int > kvp in allItem)
        //     {
        //         if(HouseInventorySystem.GetEquipmentAmount(kvp.Key) == 0) return;    
        //         var fuel = kvp.Key as Fuel;
        //         Debug.Log(fuel.name);
        //         if(IsItemInstantiated(fuel) == false)
        //         {
        //             GameObject obj = Instantiate(fuelUI , inventoryContent);
        //             fuelUIScript = obj.GetComponent<FuelUI>();
        //             fuelUIScript.SetCraftedEquipment(fuel);  
        //         }
        //         else{
        //             // HouseInventorySystem.StackEquipmentAmount(kvp.Key ,1);
        //         }
        //     }
        // }
        OnShowList?.Invoke();
        itemList = HouseInventorySystem.GetItemListWithOutAmount();
        itemAmountList = HouseInventorySystem.GetItemAmountList();
        foreach(Item item in itemList)
        {
            Fuel fuel = item as Fuel;
            if(IsItemInstantiated(fuel) == false)
            {
                GameObject obj = Instantiate(fuelUI , inventoryContent);
                fuelUIScript = obj.GetComponent<FuelUI>();
                fuelUIScript.SetCraftedEquipment(fuel);  
            }

        }
    }

    public void ClearList(){
        foreach (Transform item in inventoryContent){
           Destroy(item.gameObject);
        }
        itemList.Clear();
        itemAmountList.Clear();
    }


    private bool IsItemInstantiated(Item fuel){
        Item searchedItem = null;
        foreach(Transform item in inventoryContent){
            fuelUIScript = item.gameObject.GetComponent<FuelUI>();
            searchedItem = fuelUIScript.GetCraftedItem();
            if(fuel == searchedItem){
                return true;
            }
        }
        return false;
    }


}
