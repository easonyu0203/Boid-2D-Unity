using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/BoidMovementWeights")]
public class BoidMovementWeights : ScriptableObject
{
    [Range(0, 1)] public float weightDefault;
    [Range(0, 1)] public float weight1;
    [Range(0, 1)] public float weight2;
    [Range(0, 1)] public float weight3;
}
