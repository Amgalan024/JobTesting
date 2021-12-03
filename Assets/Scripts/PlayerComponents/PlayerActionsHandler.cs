using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerActionsHandler : MonoBehaviour
{
    [SerializeField] private BombInstantiator bombInstantiator;
    public void InstatiateBomb()
    {
        bombInstantiator.InstatiateBomb();
    }

}
