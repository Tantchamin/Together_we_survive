using UnityEngine;
public class AllDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending, endButton;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == true && EndingManageScript.IsMotherDead == true && 
        EndingManageScript.IsSisterDead == true && EndingManageScript.IsBrotherDead == true)
        {
            ending.SetActive(true);
            endButton.SetActive(true);
            HouseInventorySystem.ClearHouseInventory();
        }
    }
}
