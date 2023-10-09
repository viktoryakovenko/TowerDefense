using System;

[Serializable]
public class GameData
{
    public int Coins { get; set; } 

    public GameData()
    {
        Coins = 0;
    }
}