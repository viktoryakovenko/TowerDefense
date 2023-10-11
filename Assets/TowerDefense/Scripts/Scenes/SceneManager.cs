namespace Architecture
{
    public sealed class SceneManager : SceneManagerBase
    {
        public override void InitScenesMap()
        {
            SceneConfigMap[BootstrapSceneConfig.SCENE_NAME] = new BootstrapSceneConfig();
            SceneConfigMap[GameplaySceneConfig.SCENE_NAME] = new GameplaySceneConfig();
            SceneConfigMap[MainMenuSceneConfig.SCENE_NAME] = new MainMenuSceneConfig();
        }
    }
}