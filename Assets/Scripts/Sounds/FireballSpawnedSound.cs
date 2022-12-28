using UnityEngine;

public class FireballSpawnedSound : MonoBehaviour
{
    [SerializeField] private AudioSource _fireballSound;
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.FireballSpawned += PlayFireballSound;
    }

    private void PlayFireballSound()
    {
        _fireballSound.Play();
    }

    private void OnDisable()
    {
        _eventManager.FireballSpawned -= PlayFireballSound;
    }

}

