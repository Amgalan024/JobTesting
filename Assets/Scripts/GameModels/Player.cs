using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Player
{
    public event Action<int> OnHealthChanged;
    public event Action OnPlayerDied;
    public PlayerState State { set; get; }
    public MoveStates MoveState { set; get; }
    public int HealthPoints { private set; get; }
    public float MoveSpeed { private set; get; }

    public Player(int healthPoints, float moveSpeed)
    {
        State = PlayerState.Idle;
        HealthPoints = healthPoints;
        MoveSpeed = moveSpeed;
    }
    public void TakeDamage(int damage)
    {
        HealthPoints -= damage;
        if (HealthPoints <= 0)
        {
            HealthPoints = 0;
            State = PlayerState.Dead;
            OnPlayerDied?.Invoke();
        }
        OnHealthChanged.Invoke(HealthPoints);
    }
    public void HealPlayer(int heal)
    {
        HealthPoints += heal;
        OnHealthChanged.Invoke(HealthPoints);
    }
}
public enum PlayerState
{
    Idle,
    Dead
}
public enum MoveStates
{
    MoveUp,
    MoveDown,
    MoveRight,
    MoveLeft,
}
