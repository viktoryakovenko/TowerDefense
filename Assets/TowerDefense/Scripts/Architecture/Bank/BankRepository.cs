using UnityEngine;

namespace Architecture
{
    public class BankRepository : Repository
    {
        public int Coins { get; set; }

        private Storage _storage;
        private GameData _bankData;

        public override void Initialize()
        {
            _storage = new Storage();
            _bankData = (GameData) _storage.Load(new GameData());

            Coins = _bankData.Coins;
        }

        public override void Save()
        {
            _bankData.Coins = Coins;
            _storage.Save(_bankData);
        }
    }    
}