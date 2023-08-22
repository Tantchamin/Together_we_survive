using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Equipment axe;
    public Equipment bullet; 
    public Equipment handGun;
    void Start()

    {
        HouseInventory.AddInventory(axe , 1);
        HouseInventory.AddInventory(bullet , 50);
        HouseInventory.AddInventory(handGun , 1);
        HouseInventory.PrintInventory();
        HouseInventory.RemoveFromInventory(1);
        Debug.Log("--------");
        HouseInventory.PrintInventory();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
