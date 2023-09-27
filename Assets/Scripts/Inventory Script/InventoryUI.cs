using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private CraftedEquipment craftedEquipment;
    [SerializeField] private TextMeshProUGUI equipmentName;
    [SerializeField] private TextMeshProUGUI equipmentAmount;
    [SerializeField] private Image equipmentSprite;

    private void OnEnable() {
        InventoryManager.OnStack += UpdateText;
    }

    private void OnDisable() {
        InventoryManager.OnStack -= UpdateText;
    }
    public void SetCraftedEquipment(CraftedEquipment equipment){
        craftedEquipment = equipment;
        SetInvetoryItem();
        ConsumableItem();
    }

    private void SetInvetoryItem(){
        equipmentName.text = craftedEquipment.equipmentName;
        equipmentSprite.sprite  = craftedEquipment.equipmentIcon;
        
    }

    private void ConsumableItem(){
        if(craftedEquipment.itemType == Equipment.ItemType.Consumable){
            equipmentAmount.text = HouseInventorySystem.GetEquipmentAmount(craftedEquipment).ToString();   
        }
        else{
            equipmentAmount.enabled = false;
        }
    }

    public void UpdateText(){
        equipmentAmount.text = HouseInventorySystem.GetEquipmentAmount(craftedEquipment).ToString();   
    }

    public CraftedEquipment GetCraftedEquipment(){
        return craftedEquipment;
    }

    

}
