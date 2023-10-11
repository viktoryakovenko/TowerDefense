using System;
using System.Collections.Generic;
using Architecture;

public class BootstrapSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "Bootstrap";
    public override string SceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();



        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();



        return repositoriesMap;
    }
}
