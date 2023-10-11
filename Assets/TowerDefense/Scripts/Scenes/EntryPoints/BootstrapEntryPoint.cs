using System.Collections;
using Architecture;
using UnityEngine;

public class BootstrapEntryPoint : MonoBehaviour
{
    //TODO: Make Coroutines
    private IEnumerator Start()
    {
        Game.Run();

        ServiceLocator.RegisterService(new Storage());
        ServiceLocator.RegisterService(new GameData());

        yield return new WaitForSeconds(0.1f);

        SceneNavigator.OpenMainMenu();
    }
}
 