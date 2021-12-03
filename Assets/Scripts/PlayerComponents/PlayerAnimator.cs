using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class PlayerAnimator : MonoBehaviour, IPlayerComponent
{
    public Player Player { get; set; }
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.Play(Player.MoveState.ToString());
    }
    public void InitializePlayer(Player player)
    {
        Player = player;
    }
}
