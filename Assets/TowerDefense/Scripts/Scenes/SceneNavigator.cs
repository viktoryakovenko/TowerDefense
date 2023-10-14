using System.Collections;
using Architecture;
using UnityEditor;
using UnityEngine;

public static class SceneNavigator
{
    public static void StartGame()
    {
        Coroutines.StartRoutine(LoadSceneRoutine(GameplaySceneConfig.SCENE_NAME));
    }

    public static void OpenSettings()
    {
        //Settings Popup
        Debug.Log("Settings");
    }

    public static void OpenMainMenu()
    {
        Coroutines.StartRoutine(LoadSceneRoutine(MainMenuSceneConfig.SCENE_NAME));
    }


    private static IEnumerator LoadSceneRoutine(string sceneName)
    {
        yield return Game.SceneManager.LoadNewSceneAsync(sceneName);
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
