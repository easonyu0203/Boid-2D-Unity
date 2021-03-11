using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeightUI : MonoBehaviour
{
    [SerializeField] FloatVariable _weight;
    [SerializeField] TextMeshProUGUI _textMesh;
    [SerializeField] Slider _slider;
    [SerializeField] string displayText;

    private void Start()
    {
        _textMesh.text = displayText + $"{Mathf.Round(_weight.Value * 10) / 10}";
        _slider.value = _weight.Value;
    }


    public void OnSliderValueChange()
    {
        _weight.Value = _slider.value;
    }

    public void OnWeightChange()
    {
        _textMesh.text = displayText + $"{Mathf.Round(_weight.Value * 10) / 10}";
    }
}
