using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStatsPanel : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    private Player player;
    public void InitializeStatsPanel(Player player)
    {
        this.player = player;
        healthBar.maxValue = player.HealthPoints;
        healthBar.value = player.HealthPoints;
        this.player.OnHealthChanged += OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(int health)
    {
        healthBar.value = health;
    }
}
