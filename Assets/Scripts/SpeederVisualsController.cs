using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederVisualsController : MonoBehaviour
{

    [SerializeField]
    PhysicsSpecialPhysicsPropertiesController _psp;

    [SerializeField] float maxHorizontalRotation;
    [SerializeField] AnimationCurve maxSpeedPercentEffectMult;

    [SerializeField] float maxVerticalTilt;


    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(_psp.AnglePercent * maxSpeedPercentEffectMult.Evaluate(_psp.VelPercent) * maxHorizontalRotation, 0,_psp.VelPercent * maxVerticalTilt));

        transform.localRotation = rotation;
    }
}
