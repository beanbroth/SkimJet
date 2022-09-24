using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardForce : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float _speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _rb.velocity = new Vector3(1, 0, 0) * _speed;
    }
}
