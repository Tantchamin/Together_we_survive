using System.Collections.Generic;
using UnityEngine;

public abstract class BonfireFuel : MonoBehaviour
{
    public abstract void ShowList();
    public abstract void ClearList();

    protected abstract bool IsItemInstantiated(Item fuel);

}
    
