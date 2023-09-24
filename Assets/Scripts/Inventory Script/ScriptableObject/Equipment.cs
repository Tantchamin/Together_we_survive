using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "SeniorProjectGame/Equipment", order = 0)]
public class Equipment : ScriptableObject {

    public string equipmentName; 
    public int ID; 

    [TextArea (4,4)]
    public string description;

   
    public int durability;
    public Sprite equipmentIcon;
    public bool isConsumable = false;
    public bool isCraftAble = false;
    
    


}
