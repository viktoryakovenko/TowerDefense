using System;

public class MainCastle: IDamagable
{
    public event Action OnCastleDestroy;
    private int _hp;

    public void TakeDamage(int amount)
    {
        if (amount <= 0) 
            throw new ArgumentOutOfRangeException("Damage amount is less than or equals to zero."); 

        _hp -= amount;
    }

    private void DestroyCastle() 
    {
        if (_hp <= 0)
        {
            
        }
    }
}