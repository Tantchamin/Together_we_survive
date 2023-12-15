using UnityEngine;

public class MotherDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending, endButton;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == false && EndingManageScript.IsMotherDead == true && 
        EndingManageScript.IsSisterDead == false && EndingManageScript.IsBrotherDead == false)
        {
            ending.SetActive(true);
            endButton.SetActive(true);
            HouseInventorySystem.ClearHouseInventory();
        }
    }
}
