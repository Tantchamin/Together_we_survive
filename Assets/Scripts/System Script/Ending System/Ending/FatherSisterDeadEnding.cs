using UnityEngine;

public class FatherSisterDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending, endButton;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == true && EndingManageScript.IsMotherDead == false && 
        EndingManageScript.IsSisterDead == true && EndingManageScript.IsBrotherDead == false)
        {
            ending.SetActive(true);
            endButton.SetActive(true);
            HouseInventorySystem.ClearHouseInventory();
        }
    }
}
