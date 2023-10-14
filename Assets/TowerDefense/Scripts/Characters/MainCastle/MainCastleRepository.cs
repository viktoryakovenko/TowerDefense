using System;
using Architecture;

public class MainCastleRepository: Repository
{
    public int Hp 
        { 
            get
            {
                return _hp;
            } 
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value));
                
                _hp = value;
            }
        }

    private int _hp;

    public override void Initialize()
    {
        var gameData = (GameData) ServiceLocator.GetService<Storage>().Load();
        Hp = gameData.CastleHp;
    }

    public override void Save()
    {
        var gameData = ServiceLocator.GetService<GameData>();
        gameData.CastleHp = Hp;
    }
}