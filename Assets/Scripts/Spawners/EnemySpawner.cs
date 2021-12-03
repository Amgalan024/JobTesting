using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Pathfinding;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyBuilder enemyPrefab;
    private EnemyBuilder enemy;
    public void Spawn(Transform playerTransform)
    {
        enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        enemy.InitializeEnemy();
        enemy.GetComponentInChildren<EnemyMovement>().PlayerTransform = playerTransform;
    }
}
