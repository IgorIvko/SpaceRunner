using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseScreen;
    private Button _pause;

    void Start()
    {
        _pause = GetComponent<Button>();
        _pause.onClick.AddListener(MakePause);        
    }

    private void MakePause()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            _pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            _pauseScreen.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
