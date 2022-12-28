using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private EventManager _eventManager;
    private float _step;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.AddSpeed += AddSpeed;
    }

    private void Update()
    {
        _step = _speed * Time.deltaTime;
        transform.position -= new Vector3(_step, 0, 0);
    }

    public void AddSpeed(float boost) => _speed += boost;    

}
