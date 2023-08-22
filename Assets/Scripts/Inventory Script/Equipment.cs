using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "SeniorProjectGame/Equipment", order = 0)]
public class Equipment : ScriptableObject {

    public string equiptmentName; 
    public int equipmentID; 

    [TextArea (4,4)]
    public string description;

   
    public int equiptmentdurability;
    public Sprite equiptmentIcon;
    public bool isConsumable = false;

}
