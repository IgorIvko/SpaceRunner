using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(SpawnPoints))]
public class Spawner : MonoBehaviour
{
    public ComponentInfo[] _components;
    [HideInInspector] public ComponentInfo[] _componentsForSpawn;
    private EventManager _eventManager;
    private SpawnPoints _spawnPoints;
    private Enemy _enemy;
    private List<int> _spawnPrevPoints = new List<int>();
    private int _pointIndex = -1;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _spawnPoints = GetComponent<SpawnPoints>();
    }

    private void Start()
    {
        foreach (ComponentInfo component in _components)
            CreateToPool(component.PoolList, component.Prefab, component.Container, component.PoolLength);
        _componentsForSpawn = Array.FindAll(_components, p => p.TimeOfSpawn > 0);
    }

    private void Update()
    {
        foreach (ComponentInfo component in _componentsForSpawn)
        {
            if (component.CurrentTime > component.TimeOfSpawn)
            {
                int spawnPointIndex = CreateNewSpawnPointIndex();
                Vector3 spawnPosition = _spawnPoints.Points[spawnPointIndex].position;
                TakeFromPool(component.Prefab, spawnPosition);
                component.CurrentTime -= component.TimeOfSpawn;
            }
            component.CurrentTime += Time.deltaTime;
        }
    }

    public void CreateToPool(List<GameObject> poolList, GameObject prefab, GameObject container, int poolLength)
    {
        for (int i = 0; i < poolLength; i++)
        {
            poolList.Add(Instantiate(prefab, container.transform));
            poolList[poolList.Count - 1].SetActive(false);
        }
    }

    public void TakeFromPool(GameObject prefab, Vector3 position)
    {
        ComponentInfo component = Array.Find(_components, p => p.Prefab == prefab);
        GameObject item = component.PoolList.First(p => p.activeSelf == false);
        item.transform.position = position;
        item.SetActive(true);
    }

    public void StopSpawnObjects() => _componentsForSpawn = new ComponentInfo[0];

    private int CreateNewSpawnPointIndex()
    {        
        Predicate<int> pointIsRepeatedTwice = (int index) => index == _spawnPrevPoints[_spawnPrevPoints.Count - 1] && index == _spawnPrevPoints[_spawnPrevPoints.Count - 2];
        while (_spawnPrevPoints.Count < 3 || pointIsRepeatedTwice(_pointIndex))
        {
            _pointIndex = UnityEngine.Random.Range(0, _spawnPoints.Points.Length);
            _spawnPrevPoints.Add(_pointIndex);
        }
        _spawnPrevPoints.RemoveAt(0);
        return _pointIndex;
    }
}

[Serializable]
public class ComponentInfo
{
    public GameObject Prefab;
    public GameObject Container;
    public int PoolLength;
    public float TimeOfSpawn;
    [HideInInspector] public float CurrentTime = 0;
    [HideInInspector] public List<GameObject> PoolList = new List<GameObject>();  
}