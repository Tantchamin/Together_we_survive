using UnityEngine;

public class SisterBrotherDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending, endButton;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == false && EndingManageScript.IsMotherDead == false && 
        EndingManageScript.IsSisterDead == true && EndingManageScript.IsBrotherDead == true)
        {
            ending.SetActive(true);
            endButton.SetActive(true);
            HouseInventorySystem.ClearHouseInventory();
        }
    }
}