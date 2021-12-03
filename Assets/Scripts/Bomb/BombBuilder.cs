using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BombBuilder : MonoBehaviour
{
    [SerializeField] private int bombExplosionDamage;
    [SerializeField] private float bombExplosionDelayTime;
    private Bomb bomb;
    private void Start()
    {
        InitializeBomb();
    }
    public void InitializeBomb()
    {
        bomb = new Bomb(bombExplosionDamage, bombExplosionDelayTime);
        foreach (var component in GetComponents<IBombComponent>())
        {
            component.InitializeBomb(bomb);
        }
        foreach (var component in GetComponentsInChildren<IBombComponent>())
        {
            component.InitializeBomb(bomb);
        }
    }
}
