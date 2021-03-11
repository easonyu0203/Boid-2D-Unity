using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/BoidMovementWeights")]
public class BoidMovementWeights : ScriptableObject
{
    [Range(0, 1)] public float weightforward;
    [Range(0, 1)] public float weightCohesion;
    [Range(0, 1)] public float weightSeparation;
    [Range(0, 1)] public float weightAlignment;
}
