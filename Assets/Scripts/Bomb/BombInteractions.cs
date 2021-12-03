using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class BombInteractions : MonoBehaviour, IBombComponent
{
    public Bomb Bomb { set; get; }
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<PlayerBuilder>())
        {
            Explode();
        }
        if (collision.gameObject.GetComponent<EnemyBuilder>())
        {
            Explode();
        }
    }
    public void InitializeBomb(Bomb bomb)
    {
        Bomb = bomb;
    }
    private void Explode()
    {
        animator.Play("Explode");
    }
    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
