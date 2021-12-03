using Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IEnemyComponent
{
    [SerializeField] private float agroRadius;
    [SerializeField] private float turnfloat;
    private AIDestinationSetter aIDestinationSetter;
    private AIPath aIPath;
    public Enemy Enemy { get; set; }
    public Transform PlayerTransform { set; get; }
    private Rigidbody2D rigidbody2d;
    private void Awake()
    {
        rigidbody2d = GetComponentInParent<Rigidbody2D>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, PlayerTransform.position) <= agroRadius && Enemy.State != EnemyState.Dirty)
        {
            aIDestinationSetter.target = PlayerTransform;
            HandleMoveState();
        }
        else
        {
            aIDestinationSetter.target = null;
        }
    }
    public void InitializeEnemy(Enemy enemy)
    {
        Enemy = enemy;
        Enemy.OnEnemyDied += OnEnemyDied;
    }
    private void OnEnemyDied()
    {
        rigidbody2d.velocity = new Vector2(0,0);
        rigidbody2d.isKinematic = true;
        aIPath.enabled = false;
    }

    private void HandleMoveState()
    {
        if (Math.Abs(transform.position.x - PlayerTransform.position.x) > turnfloat)
        {
            if (transform.position.x > PlayerTransform.position.x)
            {
                Enemy.MoveState = MoveStates.MoveLeft;
            }
            else
            {
                Enemy.MoveState = MoveStates.MoveRight;
            }
        }
        else
        {
            if (transform.position.y > PlayerTransform.position.y)
            {
                Enemy.MoveState = MoveStates.MoveDown;
            }
            else
            {
                Enemy.MoveState = MoveStates.MoveUp;
            }
        }

    }
}
