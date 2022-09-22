using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceAtPosition : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float _speed;

    [SerializeField]
    //Vector3 _forceDirection;

    [SerializeField]
    Transform _forcePos;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _rb.AddForceAtPosition(transform.right * _speed, _forcePos.position);
    }
}
