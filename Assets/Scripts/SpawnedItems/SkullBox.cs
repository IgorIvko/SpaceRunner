using UnityEngine;

public class SkullBox : MonoBehaviour
{    
    private Hero _hero;
    private Wall _enemyDestroyer;
    private Bullet _bullet;    
    private EventManager _eventManager;

    private void Awake() => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Hero>(out _hero))
        {
            _eventManager.SkullBoxBang?.Invoke();
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
