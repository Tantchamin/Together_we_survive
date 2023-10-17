using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SResourceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemAmount;
    [SerializeField] private Image itemSprite;

    public void SetItem(Sprite image , byte value)
    {
        itemSprite.sprite = image;
        itemAmount.text = value.ToString();
    }
}
