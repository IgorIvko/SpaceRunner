using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Score : MonoBehaviour
{          
    [SerializeField] private int _bossActive;    
    [SerializeField] private int _deadEnemyScore;
    private EventManager _eventManager;
    private Spawner _spawner;
    private TextMeshProUGUI _textMeshPro;    

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _spawner = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();
        _textMeshPro = GetComponent<TextMeshProUGUI>();        
    }

    private void Start() => _eventManager.EnemyDie += AddScore;

    private void OnDisable() => _eventManager.EnemyDie -= AddScore;

    private void AddScore(Vector3 position)
    {
        _textMeshPro.text = (Convert.ToInt32(_textMeshPro.text) + _deadEnemyScore).ToString();    
        if(Convert.ToInt32(_textMeshPro.text) >= _bossActive)        
            BossActivate();        
    }    

    private void BossActivate()
    {
        _spawner.StopSpawnObjects();
        _eventManager.BossSpawned?.Invoke();        
        gameObject.SetActive(false);
    }
}
