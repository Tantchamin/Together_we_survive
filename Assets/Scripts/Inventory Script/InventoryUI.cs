using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private CraftedEquipment craftedEquipment;
    [SerializeField] private TextMeshProUGUI equipmentName;
    [SerializeField] private TextMeshProUGUI equipmentAmount;
    [SerializeField] private Image equipmentSprite;


    public void SetCraftedEquipment(CraftedEquipment equipment){
        craftedEquipment = equipment;
        SetInvetoryItem();
    }

    private void SetInvetoryItem(){
        equipmentName.text = craftedEquipment.equipmentName;
        equipmentSprite.sprite  = craftedEquipment.equipmentIcon;
        if(craftedEquipment.itemType != Equipment.ItemType.Consumable){
            equipmentAmount.enabled = false;
        }
        else{
            equipmentAmount.text = HouseInventorySystem.GetEquipmentAmount(craftedEquipment).ToString();
        }
    }

}
