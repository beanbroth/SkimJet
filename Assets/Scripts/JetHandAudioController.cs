using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSAM;

public class JetHandAudioController : MonoBehaviour
{
    [SerializeField] AddForceAtPosition _afa;

    AudioSource engine;
    AudioSource whine;


    void Start()
    {
        engine = AudioManager.PlaySoundLoop(Sounds.RocketEngine, transform);
        whine = AudioManager.PlaySoundLoop(Sounds.RocketWhine,transform);

    }

    // Update is called once per frame
    void Update()
    {
        whine.pitch = 0.8f + _afa.ThrottlePercent*0.2f;
        engine.volume = 1 + _afa.ThrottlePercent;

    }
}
