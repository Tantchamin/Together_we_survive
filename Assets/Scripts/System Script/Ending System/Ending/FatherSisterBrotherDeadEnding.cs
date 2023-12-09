using UnityEngine;

public class FatherSisterBrotherDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending, endButton;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == true && EndingManageScript.IsMotherDead == false && 
        EndingManageScript.IsSisterDead == true && EndingManageScript.IsBrotherDead == true)
        {
            ending.SetActive(true);
            endButton.SetActive(true);
        }
    }
}
