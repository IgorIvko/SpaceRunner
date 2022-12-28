using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ToMainMenu : MonoBehaviour
{
    private Button _ToMainMenuButton;

    private void Start()
    {
        _ToMainMenuButton = GetComponent<Button>();
        _ToMainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(0);        
    }
}
