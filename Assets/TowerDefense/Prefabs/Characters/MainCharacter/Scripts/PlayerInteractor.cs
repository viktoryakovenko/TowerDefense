using Architecture;
using UnityEngine;

public class PlayerInteractor: Interactor
{
    public Player Player { get; private set; }

    public override void Initialize()
    {
        base.Initialize();

        var goPlayer = new GameObject("Player");
        Player = goPlayer.AddComponent<Player>();
    }
}