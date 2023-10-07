using System;

namespace Architecture
{
    public static class Bank
    {
        public static event Action OnBankInitializedEvent;

        public static int Coins 
        {
            get 
            {
                CheckClass();
                return _bankInteractor.Coins;
            }
        }

        public static bool IsInitialized { get; private set; }

        private static BankInteractor _bankInteractor;

        public static void Initialize(BankInteractor bankInteractor)
        {
            _bankInteractor = bankInteractor;
            IsInitialized = true;

            OnBankInitializedEvent?.Invoke();
        }

        public static bool IsEnoughCoins(int value)
        {
            CheckClass();
            return _bankInteractor.IsEnoughCoins(value);
        }

        public static void AddCoins(object sender, int value)
        {
            CheckClass();
            _bankInteractor.AddCoins(sender, value);
        }

        public static void SpendCoins(object sender, int value)
        {
            CheckClass();
            _bankInteractor.SpendCoins(sender, value);
        }

        private static void CheckClass()
        {
            if (!IsInitialized)
                throw new Exception("Bank is not initialized yet");
        }
    }
}