using UnityEngine;

public class AsteroidDestroyedSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private EventManager _eventManager;
    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.AsteroidDestroyed += PlayBangSound;
    }

    private void OnDisable()
    {
        _eventManager.AsteroidDestroyed -= PlayBangSound;
    }

    private void PlayBangSound(Vector3 point)
    {
        _audioSource.Play();
    }

}
