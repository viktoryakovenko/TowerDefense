using System;
using System.Collections;
using System.Collections.Generic;
using Architecture;
using UnityEngine;

public abstract class SceneManagerBase
{
    public event Action<Scene> OnSceneLoadedEvent;

    public Scene Scene { get; private set; } 
    public bool IsLoading { get; private set; }

    protected Dictionary<string, SceneConfig> SceneConfigMap { get; private set; }

    public SceneManagerBase()
    {
        SceneConfigMap = new Dictionary<string, SceneConfig>();
    }

    public abstract void InitScenesMap();

    public Coroutine LoadCurrentSceneAsync()
    {
        if(IsLoading)
            throw new Exception("Scene is loading now");

        var sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        var config = SceneConfigMap[sceneName];
        return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
    }

    public Coroutine LoadNewSceneAsync(string sceneName)
    {
        if(IsLoading)
            throw new Exception("Scene is loading now");

        var config = SceneConfigMap[sceneName];
        return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
    }

    private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
    {
        IsLoading = true;

        yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

        IsLoading = false;
        OnSceneLoadedEvent?.Invoke(Scene);
    }

    private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
    {
        IsLoading = true;

        yield return Coroutines.StartRoutine(LoadSceneRoutine(sceneConfig));
        yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

        IsLoading = false;
        OnSceneLoadedEvent?.Invoke(Scene);
    }
    
    private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
    {
        var async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneConfig.SceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f) 
            yield return null;

        async.allowSceneActivation = true;
    }

    private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
    {
        Scene = new Scene(sceneConfig);
        yield return Scene.InitializeAsync();
    }

    public T GetRepository<T>() where T: Repository
    {
        return Scene.GetRepository<T>();
    }

    public T GetInteractor<T>() where T: Interactor
    {
        return Scene.GetInteractor<T>();
    }
}