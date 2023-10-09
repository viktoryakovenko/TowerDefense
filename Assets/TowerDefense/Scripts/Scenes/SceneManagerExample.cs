public sealed class SceneManagerExample : SceneManagerBase
{
    public override void InitScenesMap()
    {
        SceneConfigMap[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
    }
}