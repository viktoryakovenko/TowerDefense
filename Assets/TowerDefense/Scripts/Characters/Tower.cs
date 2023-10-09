public abstract class Tower
{
    private int _cost;
    private int _upgradeCost;
    private float _cooldown;
    private int _maxLevel;
    private int _currentLevel;

    public abstract void Attack(); 
}
