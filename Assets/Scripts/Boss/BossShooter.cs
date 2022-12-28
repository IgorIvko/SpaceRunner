using System.Collections.Generic;
using UnityEngine;

public class BossShooter : MonoBehaviour
{
    [SerializeField] private float _verticalStep;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _fireBallPrefab;
    [SerializeField, Range(1, 100)] private int _doubleDamageChance;       
    private float _currentTime = 0;
    private const float _shootDistanceFromPosition = 3f;
    private EventManager _eventManager;
    private Spawner _spawner;
    private List<float> _timeOfShootList = new List<float>();
    private int _shootIndex = 0;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _spawner = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();
        _eventManager.BossAngry += AngryShoot;
        _timeOfShootList.Add(_delay);
    }

    private void Update()
    {        
        if(_currentTime >= _timeOfShootList[_shootIndex])
        {
            Shoot();
            float lastShootTime = _timeOfShootList[_timeOfShootList.Count-1];
            int chance = Random.Range(1, 101);

            if (chance < _doubleDamageChance)               
                _timeOfShootList.Add(lastShootTime + 1.5f);
            else
                _timeOfShootList.Add(lastShootTime + _delay);
           
            _shootIndex++;     
        }
        
        _currentTime += Time.deltaTime;
    }
   
    public void Shoot()
    {
        float posY1 = transform.position.y + _verticalStep*Random.Range(-1, 2);
        float posY2 = posY1;
        while(posY1 == posY2) posY2 = transform.position.y + _verticalStep * Random.Range(-1, 2);
        
        
        float posX = transform.position.x - _shootDistanceFromPosition;                
        _spawner.TakeFromPool(_fireBallPrefab, new Vector3(posX, posY1));        
        _spawner.TakeFromPool(_fireBallPrefab, new Vector3(posX, posY2));
        _eventManager.FireballSpawned?.Invoke();        
    }


    private void AngryShoot()
    {                  
        for (float i = 1; i <= 4; i++)
        {
            float lastShootTime = _timeOfShootList[_timeOfShootList.Count-1];
            _timeOfShootList.Add(lastShootTime + 1.5f);
        }                       
    }

}
