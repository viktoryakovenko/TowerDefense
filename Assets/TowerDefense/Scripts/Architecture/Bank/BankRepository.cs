using UnityEngine;

namespace Architecture
{
    public class BankRepository : Repository
    {
        public int Coins { get; set; }

        public override void Initialize()
        {
            GameData gameData = (GameData) ServiceLocator.GetService<Storage>().Load();
            Coins = gameData.Coins;
        }

        public override void Save()
        {
            GameData gameData = ServiceLocator.GetService<GameData>();
            gameData.Coins = Coins;
            ServiceLocator.GetService<Storage>().Save(gameData);
        }
    }    
}