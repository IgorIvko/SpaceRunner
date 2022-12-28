using UnityEngine;

public class Enemy : MonoBehaviour
{    
    [SerializeField] private int _damage;           
    private Hero _hero;
    private Wall _enemyDestroyer;
    private Bullet _bullet;
    private EventManager _eventManager;

    private void Awake()  => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out _hero)) 
        {
            _hero.TakeDamage(_damage);
            Die();                                 
        }

        if(collision.TryGetComponent<Wall>(out _enemyDestroyer))
        {              
            gameObject.SetActive(false);
        }

        if(collision.TryGetComponent<Bullet>(out _bullet))
        {
            _bullet.gameObject.SetActive(false);            
            Die();            
        }
            
    }
    public void Die()
    {
        _eventManager.EnemyDie?.Invoke(transform.position);           
        gameObject.SetActive(false);
    }

}
