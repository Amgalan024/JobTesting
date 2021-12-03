using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class PlayerBuilder : MonoBehaviour
{
    [SerializeField] private int healthPoints;
    [SerializeField] private float moveSpeed;
    public Player Player { private set; get; }
    public void InitializePlayer()
    {
        Player = new Player(healthPoints, moveSpeed);
        foreach (var component in GetComponents<IPlayerComponent>())
        {
            component.InitializePlayer(Player);
        }
        foreach (var component in GetComponentsInChildren<IPlayerComponent>())
        {
            component.InitializePlayer(Player);
        }
    }
}
