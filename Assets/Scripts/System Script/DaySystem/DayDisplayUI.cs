using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayDisplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dayText;
    [SerializeField] private DayManagerScript dayManagerScript;
    private void Awake() {
        dayManagerScript.GetComponent<DayManagerScript>();
        dayManagerScript.OnDayEnd += UpdateDay;
    }
    private void UpdateDay()
    {
        dayText.text = "Day : " + dayManagerScript.GetDays();
    }
}
