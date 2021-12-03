using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    public Player Player { get; set; }
    private Rigidbody2D rigidbody2d;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    public void InitializePlayer(Player player)
    {
        Player = player;
        Player.OnPlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        rigidbody2d.velocity = new Vector2(0, 0);
        rigidbody2d.isKinematic = true;
    }

    public void UpMovement()
    {
        rigidbody2d.velocity = new Vector2(0, Player.MoveSpeed);
        Player.MoveState = MoveStates.MoveUp;
    }
    public void DownMovement()
    {
        rigidbody2d.velocity = new Vector2(0, -Player.MoveSpeed);
        Player.MoveState = MoveStates.MoveDown;
    }
    public void RightMovement()
    {
        rigidbody2d.velocity = new Vector2(Player.MoveSpeed, 0);
        Player.MoveState = MoveStates.MoveRight;
    }
    public void LeftMovement()
    {
        rigidbody2d.velocity = new Vector2(-Player.MoveSpeed, 0);
        Player.MoveState = MoveStates.MoveLeft;
    }
    public void StopMovement()
    {
        rigidbody2d.velocity = new Vector2(0, 0);
    }
}
