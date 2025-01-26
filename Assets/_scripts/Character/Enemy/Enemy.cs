using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Enemy : Character
{
    [Header("Agent")] 
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _acceleration;
    [Header("Enemy")]
    [SerializeField] private float _chaseDistance;
    [SerializeField] private float _blindChaseTime = 1f;
    
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        base.Start();
        _agent.speed = _movementSpeed;
        _agent.stoppingDistance = _stopDistance;
        _agent.acceleration = _acceleration;

        StartCoroutine(ChasePlayer());
    }

    private IEnumerator ChasePlayer()
    {
        float timer = _blindChaseTime +0.1f;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        while (true)
        {
            transform.LookAt(player.position);   
            if (!CanSeePlayer())
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
            }
            
            if (timer < _blindChaseTime)
            {
                _agent.SetDestination(player.position);
            }
            yield return null;
        }
    }

    private bool CanSeePlayer()
    {
        Ray ray = new Ray(transform.position, (Player.instance.transform.position - transform.position).normalized);
        if (Physics.Raycast(ray, out RaycastHit hit, _chaseDistance) && hit.transform.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("Active", true);
            return true;
        }
        _animator.SetBool("Active", false);
        return false;
    }

    public override void OnHit(int damage)
    {
        base.OnHit(damage);
        if (_health <= 0)
        {
            Die();
        }
    }
}
