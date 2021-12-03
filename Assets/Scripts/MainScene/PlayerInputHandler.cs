using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerActionsHandler playerActions;
    public void InitializePlayerInputHandler(PlayerMovement playerMovement, PlayerActionsHandler playerActions)
    {
        this.playerMovement = playerMovement;
        this.playerActions = playerActions;
    }
    public void MoveUp()
    {
        playerMovement.UpMovement();
    }
    public void MoveDown()
    {
        playerMovement.DownMovement();
    }
    public void MoveRight()
    {
        playerMovement.RightMovement();
    }
    public void MoveLeft()
    {
        playerMovement.LeftMovement();
    }
    public void Stop()
    {
        playerMovement.StopMovement();
    }
    public void InstantiateBomb()
    {
        playerActions.InstatiateBomb();
    }
}
