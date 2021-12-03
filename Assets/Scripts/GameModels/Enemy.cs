using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy 
{
    public event Action<int> OnHealthChanged;
    public event Action OnEnemyDied;
    public EnemyState State;
    public MoveStates MoveState;
    public int HealthPoints { private set; get; }
    public int MaxHealthPoints { private set; get; }

    public float MoveSpeed { private set; get; }

    public Enemy(int healthPoints, float moveSpeed)
    {
        State = EnemyState.Idle;
        MoveState = MoveStates.MoveLeft;
        HealthPoints = healthPoints;
        MaxHealthPoints = healthPoints;
        MoveSpeed = moveSpeed;
    }
    public void TakeDamage(int damage)
    {
        HealthPoints -= damage;
        if (HealthPoints <= MaxHealthPoints / 2)
        {
            State = EnemyState.Angry;
        }
        if (HealthPoints <= 0)
        {
            HealthPoints = 0;
            State = EnemyState.Dirty;
            OnEnemyDied?.Invoke();
        }
        Debug.Log($"Enemy HP {HealthPoints}");
        OnHealthChanged?.Invoke(HealthPoints);
    }
}
public enum EnemyState
{
    Idle,
    Angry,
    Dirty,
    Dead
}
