using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederVisualsController : MonoBehaviour
{

    [SerializeField]
    PhysicsSpecialPhysicsPropertiesController _psp;

    [SerializeField] float maxAngle;
    [SerializeField] AnimationCurve maxSpeedPercentEffectMult;


    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(_psp.AnglePercent * maxSpeedPercentEffectMult.Evaluate(_psp.VelPercent) * maxAngle, 0, 0));

        transform.localRotation = rotation;
    }
}
