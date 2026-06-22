using UnityEngine;
using TMPro;

public class MissionPopup : MonoBehaviour
{
    public TMP_Text missionText;
    public float showTime = 4f;

    void Start()
    {
        missionText.gameObject.SetActive(true);
        Invoke(nameof(HideMission), showTime);
    }

    void HideMission()
    {
        missionText.gameObject.SetActive(false);
    }
}