using UnityEngine;
using System;

public class HealthBarBoss : MonoBehaviour
{    
    [SerializeField] private Heart _prefab;
    private Heart _newHeart;
    private EventManager _eventManager;

    private void Awake() => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();

    private void OnEnable() => _eventManager.BossHealthChanged += OnHealthChanged;   

    private void OnDisable() => _eventManager.BossHealthChanged -= OnHealthChanged;

    private void OnHealthChanged(int count)
    {
        if (count <= 0)
        {
            foreach (Transform child in gameObject.transform)
                Destroy(child.gameObject);
            return;
        }

        int childCount = gameObject.transform.childCount;
        int difference = Math.Abs(childCount - count);

        if (childCount > count)
        {
            for (int i = 0; i < difference; i++)
            {
                Destroy(gameObject.transform.GetChild(childCount - i - 1).gameObject);
            }
            return;
        }

        if (childCount < count)
        {
            for (int i = 0; i < difference; i++)
            {
                _newHeart = Instantiate(_prefab, gameObject.transform);
                _newHeart.Fill();
            }

        }
    }
   
}
