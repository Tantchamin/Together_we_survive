using System.Collections.Generic;
using Unity.VisualScripting;

public static class HouseInventory {

    public static List<Equipment> houseInventory = new List<Equipment>();

    





    public static void AddInventory(Equipment equipment){


    }

    public static Equipment GetEquipment(int equipmentID){
        return houseInventory[equipmentID];
    }

}
