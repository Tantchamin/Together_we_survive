using UnityEngine;

public class MotherBrotherDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == false && EndingManageScript.IsMotherDead == true && 
        EndingManageScript.IsSisterDead == false && EndingManageScript.IsBrotherDead == true)
        {
            ending.SetActive(true);
        }
    }
}
