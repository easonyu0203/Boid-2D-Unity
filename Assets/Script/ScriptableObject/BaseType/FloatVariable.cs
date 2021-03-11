using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Float Variable")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] GameEvent OnValueChange;

    [SerializeField] float _value;
    public float Value
    {
        get { return _value; }
        set
        {
            _value = value;

            if (OnValueChange != null) OnValueChange.Raise();
        }
    }

}
