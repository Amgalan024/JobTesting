using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour, IPlayerComponent
{
    public Player Player { get; set; }
    public void InitializePlayer(Player player)
    {
        Player = player;
        Player.OnHealthChanged += Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(int obj)
    {
        Debug.Log("Damaged");
    }

    private void OnTriggerEnter2D(Collider2D colllider)
    {
        if (colllider.GetComponent<BombExplosion>())
        {
            Player.TakeDamage(colllider.GetComponent<BombExplosion>().Bomb.ExplosionDamage);
        }
        if (colllider.GetComponent<EnemyInteractions>())
        {
            Player.TakeDamage(Player.HealthPoints);
        }
    }
}
