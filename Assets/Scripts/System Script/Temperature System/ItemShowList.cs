using System.Collections.Generic;
using UnityEngine;

public abstract class ItemShowList : MonoBehaviour
{
    public abstract void ShowList();
    public abstract void ClearList();
    public abstract void FillList();
    protected abstract bool IsItemInstantiated(Item item);

}
    
