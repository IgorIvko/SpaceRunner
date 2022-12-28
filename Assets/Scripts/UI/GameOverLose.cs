using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverLose : MonoBehaviour
{    
    [SerializeField] GameObject _gameOverWindow;
    [SerializeField] private Button _restartButton;
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = GameObject.FindWithTag("EventManager").GetComponent<EventManager>();
        _eventManager.GameOverLose += ShowGameOverWindow;
    }

    private void OnDestroy() => _eventManager.GameOverLose -= ShowGameOverWindow;

    private void OnEnable() => _restartButton.onClick.AddListener(OnRestartButtonClick);
    
    private void OnDisable() => _restartButton.onClick.RemoveListener(OnRestartButtonClick);    

    private void ShowGameOverWindow() => _gameOverWindow.gameObject.SetActive(true);    

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
