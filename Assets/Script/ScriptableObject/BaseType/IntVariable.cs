using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="ScriptableObject/Int Variable")]
public class IntVariable : ScriptableObject
{
    [SerializeField] GameEvent OnValueChange;

    [SerializeField] int _value;
    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;

            if(OnValueChange != null) OnValueChange.Raise();
        }
    }


}
