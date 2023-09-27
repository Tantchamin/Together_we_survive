using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //  private static Dictionary<CraftedEquipment , int > inventoryDictionary = new Dictionary<CraftedEquipment, int>();
    // [SerializeField] private  List<Dictionary<CraftedEquipment , int >> craftedEquipmentList 
    // = new List<Dictionary<CraftedEquipment , int >>();

    [SerializeField] private List<CraftedEquipment> craftedEquipmentList = new List<CraftedEquipment>();

    [SerializeField] private Dictionary<CraftedEquipment , int > houseEquipmentList = new Dictionary<CraftedEquipment , int>();
    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private InventoryUI inventoryUIscript;

    static public event Action OnStack;



    private void Start() {
        // Debug.Log(inventoryContent.transform.ToString());    
    }
    public void ShowList(){

        craftedEquipmentList = HouseInventorySystem.GetEquipmentListWithOutAMount();

        


        foreach (CraftedEquipment equipment in craftedEquipmentList){       
            Debug.Log(equipment.equipmentName);
            if(IsEquipmentInstantiated(equipment) == false){
                GameObject obj = Instantiate(inventoryUI , inventoryContent);
                inventoryUIscript = obj.GetComponent<InventoryUI>();
                inventoryUIscript.SetCraftedEquipment(equipment);    
            }
            else if((equipment.itemType == Equipment.ItemType.Weapon || equipment.itemType == Equipment.ItemType.Tool) 
            && IsEquipmentInstantiated(equipment) == true){
                GameObject obj = Instantiate(inventoryUI , inventoryContent);
                inventoryUIscript = obj.GetComponent<InventoryUI>();
                inventoryUIscript.SetCraftedEquipment(equipment);    
            }
            else if(equipment.itemType == Equipment.ItemType.Consumable && IsEquipmentInstantiated(equipment) == true){
                OnStack?.Invoke();
            }

        }
    }

    public void ClearList(){
        foreach (Transform item in inventoryContent){
           Debug.Log(item.ToString());
           Destroy(item.gameObject);
        }
        craftedEquipmentList.Clear();
        
    }

    private bool IsEquipmentInstantiated(CraftedEquipment craftedEquipment){
        CraftedEquipment searchedEquipment = null;
        foreach(Transform item in inventoryContent){
            inventoryUIscript = item.gameObject.GetComponent<InventoryUI>();
            searchedEquipment = inventoryUIscript.GetCraftedEquipment();
            if(craftedEquipment == searchedEquipment){
                return true;
            }
        }
        return false;
    }

}
