using UnityEngine;

public class EnemyDieEffect: MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;      
    
    private EventManager _eventManager;
    private Spawner _spawner;   

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _spawner = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();
    }

    private void Start() => _eventManager.EnemyDie += PlayEnemyDieEffect;

    private void OnDestroy() => _eventManager.EnemyDie -= PlayEnemyDieEffect;


    private void PlayEnemyDieEffect(Vector3 position) => _spawner.TakeFromPool(_effectPrefab, position);        
    

}
