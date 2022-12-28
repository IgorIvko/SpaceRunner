using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private EventManager _eventManager;
    private Spawner _spawner;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _spawner = GameObject.FindWithTag("Spawn").GetComponent<Spawner>();
        _eventManager.HeroShoot += BullletSpawn;
    }

    private void BullletSpawn(Vector3 position) => _spawner.TakeFromPool(_bulletPrefab, position);

    private void OnDestroy() => _eventManager.HeroShoot -= BullletSpawn;

}
