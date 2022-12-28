using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class SoundButton : MonoBehaviour
{
    private Button _ToMainMenuButton;
    private EventManager _eventManager;

    private void Awake() => _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();

    private void Start()
    {
        _ToMainMenuButton = GetComponent<Button>();
        _ToMainMenuButton.onClick.AddListener(SoundOnOff);
    }

    private void SoundOnOff()
    {
        _eventManager.SoundOnOff?.Invoke();
    }
}
