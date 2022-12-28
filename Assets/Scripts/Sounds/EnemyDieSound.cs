using UnityEngine;

public class EnemyDieSound : MonoBehaviour
{   
    [SerializeField] private AudioSource _enemyDieSound;
    private EventManager _eventManager;    

    private void Start()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.EnemyDie += PlayEnemyDieSound;
    }

    private void PlayEnemyDieSound(Vector3 position)
    {
        _enemyDieSound.Play();
    }

    private void OnDisable()
    {
        _eventManager.EnemyDie -= PlayEnemyDieSound;
    }      

}
