using UnityEngine;

public class SkullBoxBangEffect : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    private EventManager _eventManager;
    private Spawner _spawner;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _spawner = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();
    }

    private void Start() => _eventManager.SkullBoxBang += PlayBangEffect;

    private void OnDestroy() => _eventManager.SkullBoxBang -= PlayBangEffect;


    private void PlayBangEffect()
    {
        _spawner.TakeFromPool(_effectPrefab, transform.position);
    }
}
