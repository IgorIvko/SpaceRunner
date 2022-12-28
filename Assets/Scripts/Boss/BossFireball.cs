using UnityEngine;

public class BossFireball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _fireBallDestroyPrefab;
    private Hero _hero;
    private Wall _wall;
    private EventManager _eventManager;
    private Bullet _bullet;

    private void Awake() => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();            

    void Update() => transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);     

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Hero>(out _hero))
        {
            _hero.TakeDamage(_damage);
            _eventManager.FireballDamage?.Invoke(transform.position);
            gameObject.SetActive(false);            
        }

        if(collision.TryGetComponent<Bullet>(out _bullet))
        {
            _eventManager.FireballDamage?.Invoke(transform.position);
            gameObject.SetActive(false);
            _bullet.gameObject.SetActive(false);
        }

        if (collision.TryGetComponent<Wall>(out _wall))
            gameObject.SetActive(false);
    }
}
