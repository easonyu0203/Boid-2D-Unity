using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBoundery : MonoBehaviour
{

    [SerializeField] Boundery _boundery;
    private Transform _myTransform;

    // Start is called before the first frame update
    void Start()
    {
        //initialize
        _myTransform = transform;
    }

    
    void FixedUpdate()
    {
        if(Mathf.Abs(_myTransform.position.x) > _boundery.XLimit)
        {
            _myTransform.position = new Vector3(-_myTransform.position.x, _myTransform.position.y, _myTransform.position.z);
        }
        if(Mathf.Abs(_myTransform.position.y) > _boundery.YLimit)
        {
            _myTransform.position = new Vector3(_myTransform.position.x, -_myTransform.position.y, _myTransform.position.z);
        }
    }
}
