using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceAtPositionDumb : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float _speed;


    //[SerializeField]
    //Vector3 _forceDirection;

    [SerializeField]
    Transform _forcePos;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForceAtPosition(transform.forward * _speed, _forcePos.position);
    }
}
