using UnityEngine;

public class FatherMotherBrotherDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == true && EndingManageScript.IsMotherDead == true && 
        EndingManageScript.IsSisterDead == false && EndingManageScript.IsBrotherDead == true)
        {
            ending.SetActive(true);
        }
    }
}
