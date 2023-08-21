using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "SeniorProjectGame/Equipment", order = 0)]
public class Equipment : ScriptableObject {

    public int equipmentID; 
    public string equiptmentName; 
    public int durability;

    public int itemStackSize;
}
