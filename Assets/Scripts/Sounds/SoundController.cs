using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Transform _sounds;
    private EventManager _eventManager;
    private AudioSource _audioController;

    private void Awake() => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();

    void Start()
    {
        _eventManager.SoundOnOff += SoundOnOff;         
    }

    private void OnDestroy()
    {
        _eventManager.SoundOnOff -= SoundOnOff;
    }
    private void SoundOnOff()
    {
        foreach(Transform item in _sounds.GetComponentsInChildren<Transform>())
        {
            if(item.TryGetComponent<AudioSource>(out _audioController))
            {
                if(_audioController.mute == false)
                    _audioController.mute = true;
                else
                    _audioController.mute = false;
            }
                 
        }
    }
}
