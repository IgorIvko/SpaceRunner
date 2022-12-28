using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image)), RequireComponent(typeof(Button))]
public class TargetButton : MonoBehaviour
{    
    [SerializeField] private float _duration;
    [SerializeField] private Hero _hero;
    private Image _image;
    private Button _targetButton;
    private EventManager _eventManager;
    private float _currentFill = 0;
    private float _currentTime = 0;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _targetButton = GetComponent<Button>();
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _targetButton.onClick.AddListener(Shoot);        
    }

    private void Shoot()
    {
        Vector3 bulletPosition = _hero.transform.position + new Vector3(1.5f, -0.1f, 0);
        _eventManager.HeroShoot?.Invoke(bulletPosition);
        Fill();
    }

    public void Fill()
    {
        _targetButton.interactable = false;       
        _currentFill = 0f;
        _currentTime = 0f;
    }

    private void Update()
    {
        if (_currentTime < _duration)
        {
            _currentFill = Mathf.Lerp(0, 1, _currentTime / _duration);
            _image.fillAmount = _currentFill;
            _currentTime += Time.deltaTime;           
        }

        if (_currentTime >= _duration)
        {
            _currentTime = _duration;
            _image.fillAmount = 1;
            _targetButton.interactable = true;
        }
    }

    
}
