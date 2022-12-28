using UnityEngine;

public class ShootSound : MonoBehaviour
{
    [SerializeField] private AudioSource _shootSound;
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.HeroShoot += PlayShootSound;
    }

    private void PlayShootSound(Vector3 position)
    {
        _shootSound.Play();
    }

    private void OnDisable()
    {
        _eventManager.HeroShoot -= PlayShootSound;
    }
}
