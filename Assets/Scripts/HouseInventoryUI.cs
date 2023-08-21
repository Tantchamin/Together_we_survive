using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseInventoryUI : MonoBehaviour
{
    public Equipment axe;
    void Start()
    {
        HouseInventory.AddInventory(axe);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
