using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyBuilder : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    [SerializeField] private float moveSpeed;
    private Enemy enemy;
    public void InitializeEnemy()
    {
        enemy = new Enemy(healthPoints, moveSpeed);
        foreach (var component in GetComponents<IEnemyComponent>())
        {
            component.InitializeEnemy(enemy);
        }
        foreach (var component in GetComponentsInChildren<IEnemyComponent>())
        {
            component.InitializeEnemy(enemy);
        }
    }

}
