using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Equipment axe;
    public Equipment bullet; 
    public Equipment handGun;

    [SerializeField] private List<CraftedEquipment> craftedEquipmentList = new List<CraftedEquipment>();

    void Start()

    {
        // HouseInventorySystem.AddEquipment(axe , 1);
        // HouseInventorySystem.AddEquipment(bullet , 50);
        // HouseInventorySystem.AddEquipment(handGun , 1);
        // HouseInventorySystem.PrintInventory();
        // HouseInventorySystem.RemoveEquipment(1);
        // Debug.Log("--------");
        // HouseInventorySystem.PrintInventory();

        // Debug.Log( HouseInventorySystem.CheckEquipment("bullet").ToString());
        // Debug.Log( HouseInventorySystem.CheckEquipment("Ammuniation").ToString());

       
        // Debug.Log( HouseInventorySystem.CheckEquipment("Hello").ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
