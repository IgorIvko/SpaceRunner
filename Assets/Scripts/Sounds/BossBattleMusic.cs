using UnityEngine;

public class BossBattleMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroungSound;
    [SerializeField] private AudioSource _bossBattleSound;
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.BossSpawned += PlayBossBattleSound;
    }

    private void PlayBossBattleSound()
    {
        _backgroungSound.Stop();
        _bossBattleSound.Play();
    }

    private void OnDisable()
    {
        _eventManager.BossSpawned -= PlayBossBattleSound;
    }
}
