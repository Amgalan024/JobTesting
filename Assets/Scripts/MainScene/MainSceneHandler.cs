using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Cinemachine;

public class MainSceneHandler : MonoBehaviour
{
    [SerializeField] private PlayerBuilder playerPrefab;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private PlayerInputHandler playerMovementHandler;
    [SerializeField] private PlayerStatsPanel playerStatsPanel;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Canvas gameLostScreen;
    [SerializeField] private EnemySpawner[] enemySpawners;
    private PlayerBuilder playerBuilder;
    private void Start()
    {
        gameLostScreen.gameObject.SetActive(false);
        playerBuilder = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
        playerBuilder.InitializePlayer();
        playerBuilder.Player.OnPlayerDied += OnPlayerDied;
        playerMovementHandler.InitializePlayerInputHandler(playerBuilder.GetComponent<PlayerMovement>(), playerBuilder.GetComponent<PlayerActionsHandler>());
        playerStatsPanel.InitializeStatsPanel(playerBuilder.Player);
        for (int i = 0; i < enemySpawners.Length; i++)
        {
            enemySpawners[i].Spawn(playerBuilder.transform);
        }
    }
    private void OnPlayerDied()
    {
        gameLostScreen.gameObject.SetActive(true);
    }
}
