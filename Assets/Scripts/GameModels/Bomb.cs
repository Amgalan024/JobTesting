using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Bomb
{
    public int ExplosionDamage { private set; get; }
    public float ExplosionDelayTime { private set; get; }
    public float ExplosionRadius;
    public Bomb(int damage, float delayTime)
    {
        ExplosionDamage = damage;
        ExplosionDelayTime = delayTime;
    }
}
