using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour, IEnemyComponent
{
    public Enemy Enemy { get; set; }
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerMoveAnimation(Enemy.State.ToString());
    }
    public void InitializeEnemy(Enemy enemy)
    {
        Enemy = enemy;
    }
    private void PlayerMoveAnimation(string StateName)
    {
        if (StateName == EnemyState.Idle.ToString())
        {
            StateName = "";
        }
        animator.Play(StateName + Enemy.MoveState.ToString());
    }
}
