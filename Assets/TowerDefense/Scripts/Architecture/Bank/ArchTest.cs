using System;
using UnityEngine;

namespace Architecture
{
    public class ArchTest : MonoBehaviour 
    {
        private Player _player;

        private void Start() 
        {
            //Without Run player is null
            Game.Run();
            Game.OnGameInitializedEvent += OnGameInitialized;
        }

        private void OnGameInitialized()
        {
            Game.OnGameInitializedEvent -= OnGameInitialized;
            var playerInteractor = Game.GetInteractor<PlayerInteractor>();
            _player = playerInteractor.Player;
        }

        private void Update() 
        {
            if (!Bank.IsInitialized)
                return;

            if (_player == null) 
                return;

            if (Input.GetKeyDown(KeyCode.W)) 
            {
                SceneNavigator.OpenMainMenu();
                Debug.Log("MainMenu");
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Bank.AddCoins(this, 5);
                Debug.Log($"Coins added (5), total: {Bank.Coins}");
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Bank.SpendCoins(this, 5); 
                Debug.Log($"Coins spent (5), total: {Bank.Coins}");
            }
        }
    }
}