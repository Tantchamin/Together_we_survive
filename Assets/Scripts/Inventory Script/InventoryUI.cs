using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Equipment craftedEquipment;
    [SerializeField] private TextMeshProUGUI equipmentName;
    [SerializeField] private TextMeshProUGUI equipmentAmount;
    [SerializeField] private TextMeshProUGUI equipmentDescription;

    [SerializeField] private GameObject equipmentDescriptionPanel;
    [SerializeField] private Image equipmentSprite;


    private void Start() {
        equipmentDescriptionPanel.SetActive(false);
    }
    public void SetCraftedEquipment(Equipment equipment){
        craftedEquipment = equipment;
        SetInvetoryItem();
        ConsumableItem();
    }

    private void SetInvetoryItem(){
        equipmentName.text = craftedEquipment.equipmentName;
        equipmentSprite.sprite  = craftedEquipment.equipmentIcon;
        equipmentDescription.text = craftedEquipment.description;
        
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

    public Equipment GetCraftedEquipment(){
        return craftedEquipment;
    }

    

}
