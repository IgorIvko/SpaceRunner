using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Exit : MonoBehaviour
{
    private Button _exitButton;

    private void Start()
    {
        _exitButton = GetComponent<Button>();
        _exitButton.onClick.AddListener(ExitApplication);        
    }

    private void ExitApplication()
    {
        Application.Quit();
    }
}
