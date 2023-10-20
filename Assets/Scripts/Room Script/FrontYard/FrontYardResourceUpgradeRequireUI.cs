using UnityEngine;
using TMPro;
using System.Collections;

public class FrontYardResourceUpgradeRequireUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodText , metalText , tapeText , dayText;  
    [SerializeField] private HouseUpgradeMaterial houseLevel1, houseLevel2, houseLevel3;
    FrontYardHouseUpgradeManager frontYardHouseUpgradeManager;
    private void OnEnable() 
    {
        frontYardHouseUpgradeManager = GetComponent<FrontYardHouseUpgradeManager>();
        FrontYardHouseUpgradeManager.OnHouseFinishUpgrade += UpdateResourceText;
        UpdateResourceText();
    }


    private void UpdateResourceText()
    {   
        if(frontYardHouseUpgradeManager.houseState == FrontYardHouseUpgradeManager.HouseState.level0)
        {
            HouselevelResource(houseLevel1);
        }
        else if(frontYardHouseUpgradeManager.houseState == FrontYardHouseUpgradeManager.HouseState.level1)
        {
            HouselevelResource(houseLevel2);
        }
        else if(frontYardHouseUpgradeManager.houseState == FrontYardHouseUpgradeManager.HouseState.level2)
        {
            HouselevelResource(houseLevel3);
        }
    }

    private void HouselevelResource(HouseUpgradeMaterial houselevel)
    {
        woodText.text = "x " + houselevel.WoodAmount.ToString();
        metalText.text = "x " + houselevel.MetalAmount.ToString();
        tapeText.text = "x "  + houselevel.TapeAmount.ToString();
        dayText.text = houselevel.UpgradeDays.ToString() + " Days";
    }
}
