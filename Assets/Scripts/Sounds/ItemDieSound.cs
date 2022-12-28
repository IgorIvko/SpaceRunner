using UnityEngine;

public class ItemDieSound : MonoBehaviour
{
    [SerializeField] private AudioSource _itemDieSound;    
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.ItemDie += PlayHealingSound;
    }

    private void PlayHealingSound(Vector3 position)
    {
        _itemDieSound.Play();
    }

    private void OnDisable()
    {
        _eventManager.ItemDie -= PlayHealingSound;
    }


}
