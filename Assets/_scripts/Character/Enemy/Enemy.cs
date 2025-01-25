using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Character
{
    [Header("Agent")] 
    [SerializeField] private float _atkRange;
    [SerializeField] private float _atkDamage;
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _acceleration;
    
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        _agent.speed = _movementSpeed;
        _agent.stoppingDistance = _stopDistance;
        _agent.acceleration = _acceleration;
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent.SetDestination(player.position);
        transform.LookAt(player.position);
    }
}
