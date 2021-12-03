using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class BombExplosion : MonoBehaviour, IBombComponent
{
    public Bomb Bomb { get; set; }
    public void InitializeBomb(Bomb bomb)
    {
        Bomb = bomb;
    }
}
