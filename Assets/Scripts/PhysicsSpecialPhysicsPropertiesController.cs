using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSAM;

public class PhysicsSpecialPhysicsPropertiesController : MonoBehaviour
{
    [SerializeField] float _maxSpeedLossPerFixedStepWhenPerpendicular;
    [SerializeField] float _maxVel;

    AudioSource windFlaps;
    AudioSource wind;

    [SerializeField] AnimationCurve audioRamp;

    float anglePercent;
    float velPercent;

    [SerializeField] Rigidbody _rb;

    public float AnglePercent { get => anglePercent;}
    public float VelPercent { get => velPercent;}

    void Start()
    {
        AudioManager.PlayMusic(Music.BackgroundMusic);
        windFlaps = AudioManager.PlaySoundLoop(Sounds.WindFlaps);
        wind = AudioManager.PlaySoundLoop(Sounds.ConstantWind); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velPercent = Mathf.Min( _rb.velocity.magnitude / _maxVel, 1f);
        
        anglePercent = Mathf.Sin(Vector3.SignedAngle(transform.right, _rb.velocity, transform.up) / 180 * Mathf.PI);

        _rb.velocity *= 1f - _maxSpeedLossPerFixedStepWhenPerpendicular * Mathf.Abs(anglePercent);

    }
    private void Update()
    {

        windFlaps.volume = audioRamp.Evaluate(velPercent);
        wind.volume = audioRamp.Evaluate(velPercent);
    }

}
