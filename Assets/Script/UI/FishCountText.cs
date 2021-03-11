using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FishCountText : MonoBehaviour
{
    [SerializeField] IntVariable _fishCount;
    [SerializeField] TextMeshProUGUI _textMesh;

    private void Start()
    {
        _textMesh.text = $"Fish Count: {_fishCount.Value}";
    }

    public void OnFishCountChange()
    {
        _textMesh.text = $"Fish Count: {_fishCount.Value}";
    }
}
