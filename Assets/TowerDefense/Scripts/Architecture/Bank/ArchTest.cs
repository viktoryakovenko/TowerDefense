using UnityEngine;

namespace Architecture
{
    public class ArchTest : MonoBehaviour 
    {
        private MainCastleInteractor _mainCastleInteractor;

        private void Start() 
        {
            Game.SceneManager.OnSceneLoadedEvent += SceneLoaded;
        }

        private void SceneLoaded(Scene scene)
        {
            Game.SceneManager.OnSceneLoadedEvent -= SceneLoaded;

            _mainCastleInteractor = scene.GetInteractor<MainCastleInteractor>();
            Instantiate(_mainCastleInteractor.MainCastle);
            _mainCastleInteractor.OnCastleDestroy += EndGame;
        }

        private void OnDisable() 
        {
            _mainCastleInteractor.OnCastleDestroy -= EndGame; 
        }

        private void EndGame()
        {
            //Show EndGame popup
            SceneNavigator.OpenMainMenu();
        }

        private void Update() 
        {
            if (!Bank.IsInitialized)
            {
                Debug.Log("Bank");
                return;
            }

            if (_mainCastleInteractor == null)
            {
                Debug.Log("Castle");
                return;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                _mainCastleInteractor.TakeDamage(10);
            }

            if (Input.GetKeyDown(KeyCode.W)) 
            {                
                var data = ServiceLocator.GetService<GameData>();
                ServiceLocator.GetService<Storage>().Save(data);
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