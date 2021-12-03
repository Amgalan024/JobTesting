using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class EnemyInteractions : MonoBehaviour, IEnemyComponent
{
    public Enemy Enemy { get ; set ; }
    private void OnTriggerEnter2D(Collider2D colllider)
    {
        if (colllider.GetComponent<BombExplosion>())
        {
            Enemy.TakeDamage(colllider.GetComponent<BombExplosion>().Bomb.ExplosionDamage);
        }
    }
    public void InitializeEnemy(Enemy enemy)
    {
        Enemy = enemy;
    }
}
