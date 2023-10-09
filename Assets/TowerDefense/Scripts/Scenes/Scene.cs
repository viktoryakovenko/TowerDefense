using System.Collections;
using Architecture;
using UnityEngine;

public class Scene
{
    private InteractorsBase _interactorsBase;
    private RepositoriesBase _repositoriesBase;
    private SceneConfig _sceneConfig;

    public Scene(SceneConfig config)
    {
        _sceneConfig = config;
        _interactorsBase = new InteractorsBase(config);
        _repositoriesBase = new RepositoriesBase(config);
    }

    public Coroutine InitializeAsync()
    {
        return Coroutines.StartRoutine(InitializeRoutine());
    }

    private IEnumerator InitializeRoutine()
    {
        _interactorsBase.CreateAllInteractors();
        _repositoriesBase.CreateAllRepositories();
        yield return null;

        _interactorsBase.SendOnCreateToAllInteractors();
        _repositoriesBase.SendOnCreateToAllRepositories();
        yield return null;

        _interactorsBase.InitializeAllInteractors();
        _repositoriesBase.InitializeAllRepositories();
        yield return null;

        _interactorsBase.SendOnStartToAllInteractors();
        _repositoriesBase.SendOnCreateToAllRepositories();
    }

    public T GetRepository<T>() where T: Repository
    {
        return _repositoriesBase.GetRepository<T>();
    }

    public T GetInteractor<T>() where T: Interactor
    {
        return _interactorsBase.GetInteractor<T>();
    }
}