using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _duration;
    private Image _heartImage;
    private float _currentFill = 0;
    private float _currentTime = 0;

    private void Awake() => _heartImage = GetComponent<Image>();

    public void Fill()
    {        
        _currentFill = 0;
        _currentTime = 0;
    }    

    private void Update()
    {
        if (_currentTime < _duration)
        {
            _currentFill = Mathf.Lerp(0, 1, _currentTime / _duration);
            _heartImage.fillAmount = _currentFill;
            _currentTime += Time.deltaTime;
        }

        if (_currentTime >= _duration)
        {
            _currentTime = _duration;
            _heartImage.fillAmount = 1;            
        }
    }

}
