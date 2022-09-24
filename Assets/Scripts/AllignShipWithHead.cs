using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignShipWithHead : MonoBehaviour
{
    [SerializeField]
    Transform _head;
    [SerializeField]
    Vector3 _offset;
    void Start()
    {
        //transform.forward = _head.forward;
    }



    // Update is called once per frame
    void LateUpdate()
    {
        transform.localPosition = new Vector3(-_head.localPosition.x, transform.localPosition.y, -_head.localPosition.z) + _offset;
        
    }
}
