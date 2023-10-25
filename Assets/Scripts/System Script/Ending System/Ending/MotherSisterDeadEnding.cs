using UnityEngine;

public class MotherSisterDeadEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == false && EndingManageScript.IsMotherDead == true && 
        EndingManageScript.IsSisterDead == true && EndingManageScript.IsBrotherDead == false)
        {
            ending.SetActive(true);
        }
    }
}
