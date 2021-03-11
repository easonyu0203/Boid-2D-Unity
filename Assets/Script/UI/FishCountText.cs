using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishCountText : MonoBehaviour
{
    [SerializeField] IntVariable _fishCount;
    [SerializeField] TextMeshProUGUI _textMesh;
    [SerializeField] Slider _slider;

    private void Start()
    {
        _textMesh.text = $"Fish Count: {_fishCount.Value}";
    }

    public void OnFishCountChange()
    {
        _textMesh.text = $"Fish Count: {_fishCount.Value}";
        _slider.value = _fishCount.Value;
    }
}
