using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftUI : MonoBehaviour
{
    
    [SerializeField] private CraftedEquipment craftedEquipment;

    [SerializeField] private TextMeshProUGUI equipmentName;
    [SerializeField] private TextMeshProUGUI equipmentDescirption;

    [SerializeField] private Image equipmentSprite;

    void Start()
    {
        equipmentName.text = craftedEquipment.equipmentName;
        equipmentDescirption.text = craftedEquipment.description;
        equipmentSprite.sprite  = craftedEquipment.equipmentIcon;
    }

    public CraftedEquipment GetCraftedEquipment(){
        return craftedEquipment;
    }
}
