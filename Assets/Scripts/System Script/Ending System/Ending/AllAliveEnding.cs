using UnityEngine;

public class AllAliveEnding : MonoBehaviour , IEnding
{
    [SerializeField] private GameObject ending;
    public void CheckEndingCondition()
    {
        if(EndingManageScript.IsFatherDead == false && EndingManageScript.IsMotherDead == false && 
        EndingManageScript.IsSisterDead == false && EndingManageScript.IsBrotherDead == false)
        {
            ending.SetActive(true);
        }
    }
}
