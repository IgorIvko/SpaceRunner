using UnityEngine;

public class SoundSkullBoxBang : MonoBehaviour
{
    [SerializeField]private AudioSource _audioSource;
    private EventManager _eventManager;
    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.SkullBoxBang += PlayBangSound;
    }

    private void OnDisable()
    {
        _eventManager.SkullBoxBang -= PlayBangSound;
    }

    private void PlayBangSound()
    {
        _audioSource.Play();
    }

}
