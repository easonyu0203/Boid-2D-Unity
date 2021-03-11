using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishCountslider : MonoBehaviour
{
    [SerializeField] IntVariable _fishCount;
    [SerializeField] Slider _slider;

    private void Start()
    {
        _slider.value = _fishCount.Value;
    }

    public void OnSliderValueChange()
    {
        _fishCount.Value = (int)_slider.value;
    }
    
}
