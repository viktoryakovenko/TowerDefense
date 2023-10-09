using System;

namespace Architecture
{
    public class BankInteractor : Interactor
    {
        private BankRepository _repository;

        public int Coins => _repository.Coins;

        public override void OnCreate()
        {
            base.OnCreate();
            _repository = Game.GetRepository<BankRepository>();
        }

        public override void Initialize()
        {
            Bank.Initialize(this);
        }

        public bool IsEnoughCoins(int value)
        {
            return Coins >= value;
        }

        public void AddCoins(object sender, int value)
        {
            if (value > 0)
            {
                _repository.Coins += value;
                _repository.Save();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Added coins count is negative");
            }
        }

        public void SpendCoins(object sender, int value)
        {
            if (IsEnoughCoins(value))
            {
                _repository.Coins -= value;
                _repository.Save();
            }
            else
            {
                throw new ArgumentOutOfRangeException("There is not enough coins");
            }
        }
    }
}