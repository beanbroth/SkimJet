using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSpecialPhysicsPropertiesController : MonoBehaviour
{
    [SerializeField] float _maxSpeedLossPerFixedStepWhenPerpendicular;
    [SerializeField] float _maxVel;

    float anglePercent;
    float velPercent;

    [SerializeField] Rigidbody _rb;

    public float AnglePercent { get => anglePercent;}
    public float VelPercent { get => velPercent;}

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velPercent = Mathf.Min( _rb.velocity.magnitude / _maxVel, 1f);
        
        anglePercent = Mathf.Sin(Vector3.SignedAngle(transform.right, _rb.velocity, transform.up) / 180 * Mathf.PI);

        _rb.velocity *= 1f - _maxSpeedLossPerFixedStepWhenPerpendicular * Mathf.Abs(anglePercent);

    }
}
