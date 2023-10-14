using System;
using Architecture;
using UnityEditor;
using UnityEngine;

public class MainCastleInteractor : Interactor, IDamagable
{
    public event Action OnCastleDestroy;

    public MainCastle MainCastle { get; private set; }

    private MainCastleRepository _castleRepository;

    public override void Initialize()
    {
        base.Initialize();

        _castleRepository = Game.GetRepository<MainCastleRepository>();
        
        var prefab = Resources.Load("Castle") as GameObject;
        MainCastle = prefab.GetComponent<MainCastle>();
    }

    public bool IsDestroyed => _castleRepository.Hp <= 0;

    public void TakeDamage(int amount)
    {
        if (amount <= 0) 
            throw new ArgumentOutOfRangeException("Damage amount is less than or equals to zero."); 

        if (MainCastle == null)
            throw new NullReferenceException(nameof(MainCastle));

        _castleRepository.Hp -= amount;
        _castleRepository.Save();

        if (IsDestroyed)
        {
            DestroyCastle();
        }

        Debug.Log($"Current Health {_castleRepository.Hp}");
    }

    private void DestroyCastle() 
    {
        GameObject.Destroy(MainCastle.gameObject);
        OnCastleDestroy?.Invoke();
    }
}
