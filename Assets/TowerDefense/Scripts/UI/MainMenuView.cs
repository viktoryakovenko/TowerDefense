using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _gameButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    private void OnEnable() 
    {        
        _gameButton.AddListener(SceneNavigator.StartGame);
        _settingsButton.AddListener(SceneNavigator.OpenSettings);
        _exitButton.AddListener(SceneNavigator.ExitGame);
    }

    private void OnDisable() 
    {
        _gameButton.RemoveListener(SceneNavigator.StartGame);
        _settingsButton.RemoveListener(SceneNavigator.OpenSettings);
        _exitButton.RemoveListener(SceneNavigator.ExitGame);
    }
}
