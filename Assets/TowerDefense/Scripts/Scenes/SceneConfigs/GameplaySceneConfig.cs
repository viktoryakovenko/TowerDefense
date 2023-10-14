using System;
using System.Collections.Generic;
using Architecture;

public class GameplaySceneConfig : SceneConfig
{
    public const string SCENE_NAME = "Gameplay";
    public override string SceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<BankInteractor>(interactorsMap);
        CreateInteractor<MainCastleInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<BankRepository>(repositoriesMap);
        CreateRepository<MainCastleRepository>(repositoriesMap);

        return repositoriesMap;
    }
}