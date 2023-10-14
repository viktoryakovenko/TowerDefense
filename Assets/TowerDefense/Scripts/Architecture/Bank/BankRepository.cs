using System;

namespace Architecture
{
    public class BankRepository : Repository
    {
        public int Coins 
        { 
            get
            {
                return _coins;
            } 
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                
                _coins = value;
            }
        }

        private int _coins;

        public override void Initialize()
        {
            var gameData = (GameData) ServiceLocator.GetService<Storage>().Load();
            Coins = gameData.Coins;
        }

        public override void Save()
        {
            var gameData = ServiceLocator.GetService<GameData>();
            gameData.Coins = Coins;
        }
    }    
}