using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //  private static Dictionary<CraftedEquipment , int > inventoryDictionary = new Dictionary<CraftedEquipment, int>();
    // [SerializeField] private  List<Dictionary<CraftedEquipment , int >> craftedEquipmentList 
    // = new List<Dictionary<CraftedEquipment , int >>();

    [SerializeField] private List<CraftedEquipment> craftedEquipmentList = new List<CraftedEquipment>();
    [SerializeField] private Transform inventoryContent;

    [SerializeField] private GameObject inventoryUI;

    private InventoryUI inventoryUIscript;
    public void ShowList(){
        
        craftedEquipmentList = HouseInventorySystem.GetEquipmentList();

        foreach (var equipment in craftedEquipmentList){       
            
            GameObject obj = Instantiate(inventoryUI , inventoryContent);
            inventoryUIscript = obj.GetComponent<InventoryUI>();
            inventoryUIscript.SetCraftedEquipment(equipment);
            
        }
    }

}
