using TMPro;
using UnityEngine;
using UnityEngine.UI;
public abstract class BonfireUI : MonoBehaviour
{
    protected abstract void SetSlider();
    public abstract void OnSetFuel();

    protected abstract void BonfireStatus(bool _isLighted);


}
