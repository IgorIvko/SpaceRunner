using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _quit;
   
    void Start()
    {
        _startGame.onClick.AddListener(StartGame);
        _quit.onClick.AddListener(Quit);    
    }    

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
