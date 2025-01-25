using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Character
{
    [Header("Enemy Stats")] 
    [SerializeField] private float _atkRange;
    [SerializeField] private float _atkDamage;
    [SerializeField] private float _stopDistance;
    
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        _agent.speed = _movementSpeed;
        _agent.stoppingDistance = _stopDistance;
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent.SetDestination(player.position);
    }
}
