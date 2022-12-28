using UnityEngine;

public class BossActivation : MonoBehaviour
{
    [SerializeField] GameObject _boss;
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.BossSpawned += BossActivate;
    }

    private void BossActivate() => _boss.gameObject.SetActive(true);

    private void OnDestroy() => _eventManager.BossSpawned -= BossActivate;

}
