using UnityEngine;

public class Boss : MonoBehaviour
{ 
    [Range(1,20)][SerializeField] private int _health;
    private Hero _hero;
    private Bullet _bullet;
    private EventManager _eventManager;   

    private void Awake() => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();     
    
    private void OnEnable() => _eventManager.BossHealthChanged?.Invoke(_health);   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Bullet>(out _bullet))
        {
            TakeDamage(1);
            _bullet.gameObject.SetActive(false);
        }

        if (collision.TryGetComponent<Hero>(out _hero))        
            _hero.Die();        
    }   

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _eventManager.BossDamaged?.Invoke(transform.position);
        _eventManager.BossHealthChanged(_health);
        
        if (_health <= 0)
        {
            Invoke("BossDie", 0.6f);
            _eventManager.BossDie?.Invoke(transform.position);
        }
        
        if (_health <= 3 && _health > 0)
            _eventManager.BossAngry?.Invoke();  
    }  
    
    private void BossDie()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;
        _eventManager.GameOverWin?.Invoke();
    }


}
