using UnityEngine;

public class AidKit : MonoBehaviour
{   
    [SerializeField] private int _addHealth;    
    private Hero _hero;
    private Wall _enemyDestroyer;
    private Bullet _bullet;
    private EventManager _eventManager;

    private void Awake() => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out _hero))
        {
            _hero.TakeDamage(-_addHealth);
            _eventManager.AidKitHealing?.Invoke(transform.position);
            gameObject.SetActive(false);
        }

        if (collision.TryGetComponent<Wall>(out _enemyDestroyer))
            gameObject.SetActive(false);

        if (collision.TryGetComponent<Bullet>(out _bullet))
        {
            _eventManager.ItemDie?.Invoke(transform.position);
            gameObject.SetActive(false);           
        }
    }    
    
}
