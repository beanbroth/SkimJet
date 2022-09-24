using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceAtPosition : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float _speed;

    [SerializeField]
    Transform _throttleNeutral;

    //[SerializeField]
    //Vector3 _forceDirection;

    [SerializeField]
    Transform _forcePos;
    [SerializeField]
    private Transform _camOffset;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float throttle = (_forcePos.localPosition.x + _camOffset.localPosition.x) - _throttleNeutral.localPosition.x;
        Debug.Log(throttle);
        _rb.AddForceAtPosition(transform.right * throttle *_speed, _forcePos.position);
    }
}