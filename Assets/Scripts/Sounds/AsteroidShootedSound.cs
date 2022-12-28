using UnityEngine;

public class AsteroidShootedSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private EventManager _eventManager;
    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.AsteroidShooted += PlayAsteroidShootedSound;
    }

    private void OnDisable()
    {
        _eventManager.SkullBoxBang -= PlayAsteroidShootedSound;
    }

    private void PlayAsteroidShootedSound()
    {
        _audioSource.Play();
    }
}
