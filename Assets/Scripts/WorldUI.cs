using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldUI : MonoBehaviour
{
    [SerializeField] Button Btn_Temp;
    [SerializeField] Slider Slider_Temp;

    private void OnClick_TemporalBtn()
    {
        Debug.Log("버튼 눌려짐");
    }

    private void OnValueChanged_Slider()
    {
        Debug.Log($"슬라이더 변경 {Slider_Temp.value}");
    }

}
