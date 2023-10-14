using UnityEngine;

public class Enemy : IMovable, IAttacker, IDamagable
{
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector3 position)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        throw new System.NotImplementedException();
    }
}