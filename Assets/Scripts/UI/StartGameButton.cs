using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private GameObject[] _objectsForStart;

    private void Awake()
    {
        Time.timeScale = 0;
        foreach (GameObject startObject in _objectsForStart)
            startObject.SetActive(false);
        _startGameButton.onClick.AddListener(StartGame);
    }        
        
    private void StartGame()
    {        
        foreach (GameObject startObject in _objectsForStart)
            startObject.SetActive(true);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
