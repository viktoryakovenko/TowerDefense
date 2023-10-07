using System;
using System.Collections.Generic;
using Architecture;

public class SceneConfigExample : SceneConfig
{
    public const string SCENE_NAME = "SampleScene";
    public override string SceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<BankInteractor>(interactorsMap);
        CreateInteractor<PlayerInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<BankRepository>(repositoriesMap);

        return repositoriesMap;
    }
}