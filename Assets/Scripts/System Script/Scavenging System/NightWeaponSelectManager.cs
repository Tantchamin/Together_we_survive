public class NightWeaponSelectManager : NightItemSelectUI
{
    private void OnEnable() 
    {
        NightSelectItemUI.OnWeaponSelected += SetItem;
        itemName.text = "Weapon";
        itemSprite.sprite = null;
    }   
    protected override void SetItem(Item item)
    {
        itemName.text = item.itemName;
        itemSprite.sprite = item.itemSprite;
    }
}
