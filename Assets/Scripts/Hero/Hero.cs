using UnityEngine;

public class Hero : MonoBehaviour
{     
    [Range(1,10), SerializeField] private int _health;    
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.HeroDie += Die;
    }

    private void Start() => _eventManager.HeroHealthChanged?.Invoke(_health);          

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _eventManager.HeroHealthChanged?.Invoke(_health);
        if (damage > 0)
            _eventManager.HeroDamaged?.Invoke();

        if (_health <= 0)
            Die();  
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Time.timeScale = 0;        
        _eventManager.GameOverLose?.Invoke();
    }
}
