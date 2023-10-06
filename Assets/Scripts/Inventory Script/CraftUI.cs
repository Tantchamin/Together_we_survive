using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftUI : MonoBehaviour
{
    
    [SerializeField] private CraftedItem craftedEquipment;

    [SerializeField] private TextMeshProUGUI equipmentName;
    [SerializeField] private TextMeshProUGUI equipmentDescirption;

    [SerializeField] private Image equipmentSprite;


    void Start()
    {
        equipmentName.text = craftedEquipment.itemName;
        equipmentDescirption.text = craftedEquipment.description;
        equipmentSprite.sprite  = craftedEquipment.itemIcon;
    }

    public CraftedItem GetCraftedEquipment(){
        return craftedEquipment;
    }
}
