using UnityEngine;

public class AidKitHealingSound : MonoBehaviour
{    
    [SerializeField] private AudioSource _healingSound;    
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.AidKitHealing += PlayHealingSound;
    }

    private void PlayHealingSound(Vector3 position)
    {
        _healingSound.Play();
    }

    private void OnDisable()
    {
        _eventManager.AidKitHealing -= PlayHealingSound;
    }    

}
