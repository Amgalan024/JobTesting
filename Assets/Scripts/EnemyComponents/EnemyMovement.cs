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
    private GameObject patrolPoint;
    public Enemy Enemy { get; set; }
    public Transform PlayerTransform { set; get; }
    private Rigidbody2D rigidbody2d;
    private AIDestinationSetter aIDestinationSetter;
    private AIPath aIPath;
    private Seeker seeker;
    private void Awake()
    {
        rigidbody2d = GetComponentInParent<Rigidbody2D>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
        aIPath = GetComponent<AIPath>();
        seeker = GetComponent<Seeker>();
     
        patrolPoint = Instantiate(new GameObject());
        RandomPatrolPointPosition();
    }
    private void FixedUpdate()
    {
        HandleMoveState();
        if (Vector2.Distance(transform.position, PlayerTransform.position) <= agroRadius && Enemy.State != EnemyState.Dirty)
        {
            aIDestinationSetter.target = PlayerTransform;
        }
        else
        {
            if (aIPath.reachedEndOfPath)
            {
                RandomPatrolPointPosition();
            }
        }
    }
    public void InitializeEnemy(Enemy enemy)
    {
        Enemy = enemy;
        aIPath.maxSpeed = Enemy.MoveSpeed;
        aIPath.maxAcceleration = Enemy.MoveSpeed;
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
        if (aIPath.velocity.normalized.y >= 0.7f && Math.Abs(aIPath.velocity.normalized.x) < 0.2f)
        {
            Enemy.MoveState = MoveStates.MoveUp;
        }
        else if(aIPath.velocity.normalized.y <= 0.7f && Math.Abs(aIPath.velocity.normalized.x) < 0.2f)
        {
            Enemy.MoveState = MoveStates.MoveDown;
        }
        else if (aIPath.velocity.normalized.x > 0.1f)
        {
            Enemy.MoveState = MoveStates.MoveRight;
        }
        if (aIPath.velocity.normalized.x < -0.1f)
        {
            Enemy.MoveState = MoveStates.MoveLeft;
        }
    }
    private void RandomPatrolPointPosition()
    {
        float randX = UnityEngine.Random.Range(-5f, 5f);
        float randY = UnityEngine.Random.Range(-5f, 5f);
        patrolPoint.transform.position = new Vector2(transform.position.x + randX, transform.position.y + randY);
        aIDestinationSetter.target = patrolPoint.transform;
    }
}
