using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
public class TempUI : MonoBehaviour
{
    [SerializeField] Button Btn_Temp;
    [SerializeField] Slider Slider_Temp;
    [SerializeField] GameObject Gun;

    private void OnEnable()
    {
        if(Btn_Temp != null)
        {
            Btn_Temp.onClick.AddListener(OnClick_TemporalBtn);
        }   

        if(Slider_Temp != null)
        {
            Slider_Temp.onValueChanged.AddListener(OnValueChanged_Slider);
        }
    }

    private void OnDisable()
    {
        if (Btn_Temp != null)
        {
            Btn_Temp.onClick.RemoveListener(OnClick_TemporalBtn);
        }

        if (Slider_Temp != null)
        {
            Slider_Temp.onValueChanged.RemoveListener(OnValueChanged_Slider);
        }

    }

    private void OnClick_TemporalBtn()
    {
        
    }

    private void OnValueChanged_Slider(float value)
    {
        Debug.Log($"�����̴� ����{Slider_Temp.value}");
    }
}
