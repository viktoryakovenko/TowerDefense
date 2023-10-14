using System;

[Serializable]
public class GameData
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

    public int CastleHp 
    { 
        get
        {
            return _castleHp;
        } 
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _castleHp = value;
        }
    } 

    private int _coins; 
    private int _castleHp;

    public GameData()
    {
        Coins = 0;
        CastleHp = 100;
    }
}