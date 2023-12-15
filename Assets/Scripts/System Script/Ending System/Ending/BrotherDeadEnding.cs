using UnityEngine;


public class BrotherDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending, endButton;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == false && EndingManageScript.IsMotherDead == false && 
        EndingManageScript.IsSisterDead == false && EndingManageScript.IsBrotherDead == true)
        {
            ending.SetActive(true);
            endButton.SetActive(true);
            HouseInventorySystem.ClearHouseInventory();
        }
    }
}
