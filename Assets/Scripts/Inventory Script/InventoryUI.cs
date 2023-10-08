using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] public static Item craftedItem;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] public TextMeshProUGUI itemAmount;
    [SerializeField] private TextMeshProUGUI itemDescription;

    [SerializeField] private GameObject itemDescriptionPanel;
    [SerializeField] private Image itemSprite;


    private void Start() {
        itemDescriptionPanel.SetActive(false);
    }
    public void SetCraftedEquipment(Item item){
        craftedItem = item;
        SetInvetoryItem();
        ConsumableItem();
    }

    private void OnEnable() {
       // HouseInventorySystem.OnValueChanged += UpdateText;
        Furnace.OnPutFuel += UpdateText;
    }
    private void OnDisable() {
       // HouseInventorySystem.OnValueChanged -= UpdateText;
        Furnace.OnPutFuel += UpdateText;

    }

    private void SetInvetoryItem(){
        itemName.text = craftedItem.itemName;
        itemSprite.sprite  = craftedItem.itemIcon;
        itemDescription.text = craftedItem.description;
        
    }

    private void ConsumableItem(){
        if(craftedItem is Fuel || craftedItem is Medicine || craftedItem is Food){
            itemAmount.text = HouseInventorySystem.GetItemAmount(craftedItem).ToString();   
        }
        else{
            itemAmount.enabled = false;
        }
    }

    public void UpdateText()
    {
        itemAmount.text = HouseInventorySystem.GetItemAmount(craftedItem).ToString();
        if(HouseInventorySystem.GetItemAmount(craftedItem) == 0)
        {
            Destroy();
        }   
    }
        


    public Item GetCraftedEquipment(){
        return craftedItem;
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

    

}
