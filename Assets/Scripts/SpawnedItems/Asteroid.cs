using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int _damage;
    private Hero _hero;
    private Wall _enemyDestroyer;
    private Bullet _bullet;
    private EventManager _eventManager;

    private void Awake() => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out _hero))
        {
            _eventManager.AsteroidDestroyed?.Invoke(transform.position);            
            gameObject.SetActive(false);
            _hero.TakeDamage(_damage);
        }

        if (collision.TryGetComponent<Wall>(out _enemyDestroyer))
            gameObject.SetActive(false);

        if (collision.TryGetComponent<Bullet>(out _bullet))
        {
            _eventManager.AsteroidShooted?.Invoke();
            _bullet.gameObject.SetActive(false);            
        }
    }

    public void DestroySelf()
    {
        _eventManager.AsteroidDestroyed?.Invoke(transform.position);
        gameObject.SetActive(false);
    }
}
