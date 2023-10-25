using UnityEngine;

public class MotherSisterBrotherDeadEnding : MonoBehaviour ,IEnding
{
    [SerializeField] private GameObject ending;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == false && EndingManageScript.IsMotherDead == true && 
        EndingManageScript.IsSisterDead == true && EndingManageScript.IsBrotherDead == true)
        {
            ending.SetActive(true);
        }
    }
}
