using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BombInstantiator : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Transform bombInstPoint;
    [SerializeField] private bool canInstantiateBomb;
    public void InstatiateBomb()
    {
        if (canInstantiateBomb)
        {
            Instantiate(bombPrefab, bombInstPoint.position, bombInstPoint.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Obstacle>() || collision.GetComponent<BombInteractions>())
        {
            canInstantiateBomb = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Obstacle>() || collision.GetComponent<BombInteractions>())
        {
            canInstantiateBomb = true;
        }
    }
}
