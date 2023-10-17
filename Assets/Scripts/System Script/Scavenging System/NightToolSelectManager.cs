public class NightToolSelectManager : NightItemSelectUI
{
    private void OnEnable() 
    {
        NightSelectItemUI.OnToolSelected += SetItem;
        itemName.text = "Tool";
        itemSprite.sprite = null;
    }   
    protected override void SetItem(Item item)
    {
        itemName.text = item.itemName;
        itemSprite.sprite = item.itemIcon;
    }


}
