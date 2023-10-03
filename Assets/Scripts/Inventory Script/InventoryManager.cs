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

    [SerializeField] private List<Equipment> craftedEquipmentList = new List<Equipment>();
    [SerializeField] private List<Weapon> weaponList = new List<Weapon>();
    [SerializeField] private List<Tool> toolList = new List<Tool>();

    [SerializeField] private Dictionary<Equipment , int > houseEquipmentList = new Dictionary<Equipment , int>();
    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private InventoryUI inventoryUIscript;

    static public event Action OnStack;



    private void Start() {
        // Debug.Log(inventoryContent.transform.ToString());    
    }
    public void ShowList(){

        craftedEquipmentList = HouseInventorySystem.GetEquipmentListWithOutAMount();
        weaponList = HouseInventorySystem.GetWeaponList();
        toolList = HouseInventorySystem.GetToolsList();
        foreach (Equipment equipment in craftedEquipmentList){       
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
           Destroy(item.gameObject);
        }
        craftedEquipmentList.Clear();
        
    }

    private bool IsEquipmentInstantiated(Equipment craftedEquipment){
        Equipment searchedEquipment = null;
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
