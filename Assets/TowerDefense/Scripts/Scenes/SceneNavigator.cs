using Architecture;
using UnityEditor;
using UnityEngine;

public static class SceneNavigator
{
    public static void StartGame()
    {
        Game.SceneManager.LoadNewSceneAsync(GameplaySceneConfig.SCENE_NAME);
    }

    public static void OpenSettings()
    {
        Debug.Log("Settings");
    }

    public static void OpenMainMenu()
    {
        Game.SceneManager.LoadNewSceneAsync(MainMenuSceneConfig.SCENE_NAME);
    }

    public static void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();          
        #endif
    }
}
