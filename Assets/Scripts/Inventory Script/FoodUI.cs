using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FoodUI : MonoBehaviour
{
    
    [SerializeField] private Food food;

    [SerializeField] private TextMeshProUGUI foodName;
    [SerializeField] private TextMeshProUGUI foodCraftingRecipe;

    [SerializeField] private Image foodSprite;


    void Start()
    {
        foodName.text = food.itemName;
        foodCraftingRecipe.text = food.CookingRecipe();
        foodSprite.sprite  = food.itemSprite;
        
    }

    public Food GetFood(){
        return food;
    }
}
