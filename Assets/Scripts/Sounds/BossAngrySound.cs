using UnityEngine;

public class BossAngrySound : MonoBehaviour
{
    [SerializeField] private AudioSource _bossAngrySound;
    private EventManager _eventManager;

    private void Start()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.BossAngry += PlayBossAngrySound;
    }

    private void PlayBossAngrySound()
    {
        _bossAngrySound.Play();
    }

    private void OnDisable()
    {
        _eventManager.BossAngry -= PlayBossAngrySound;
    }
}
