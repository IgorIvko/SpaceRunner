using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float _boostSpeed;
    [SerializeField] private float _spawnTimeDecrease;
    [SerializeField] private float _step;
    private EventManager _eventManager;
    private Spawner _spawner;
    private Enemy _enemy;
    private Asteroid _asteroid;
    private float _currentTime = 0;

    private void Awake()
    {
        _spawner = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.SkullBoxBang += DestroyEvetything;        
    }

    private void Update()
    {
        if(_currentTime > _step)
        {
            _eventManager.AddSpeed?.Invoke(_boostSpeed);
            SetTimeOfSpawn(_spawnTimeDecrease);
            _currentTime -= _step;
        }

        _currentTime += Time.deltaTime;
    }

    private void DestroyEvetything()
    {
        foreach (ComponentInfo component in _spawner._componentsForSpawn)
            foreach (GameObject item in component.PoolList)
            {
                if (item.activeSelf)
                {
                    if (item.TryGetComponent<Enemy>(out _enemy))
                    {
                        _enemy.Die();
                    }
                    else if (item.TryGetComponent<Asteroid>(out _asteroid))
                    {
                        _asteroid.DestroySelf();                        
                    }
                    else
                    {
                        item.SetActive(false);
                    }
                }
            }
    } 
    
    private void SetTimeOfSpawn(float boost)
    {
        foreach (ComponentInfo component in _spawner._componentsForSpawn)        
            component.TimeOfSpawn -= boost;            
    }

    private void OnDisable() => _eventManager.SkullBoxBang -= DestroyEvetything;        
    
}
