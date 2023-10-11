using Architecture;
using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{
    private void Start()
    {
        Game.SceneManager.InitScenesMap();

        Destroy(gameObject);
    }
}
