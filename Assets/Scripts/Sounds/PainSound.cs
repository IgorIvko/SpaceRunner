using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainSound : MonoBehaviour
{
    [SerializeField] private AudioSource _painSound;
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.HeroDamaged += PlayPainSound;
    }

    private void PlayPainSound()
    {
        _painSound.Play();
    }

    private void OnDisable()
    {
        _eventManager.HeroDamaged -= PlayPainSound;
    }


}
