using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Character
{
    [Header("Agent")] 
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _acceleration;
    [Header("Enemy")]
    [SerializeField] private float _chaseDistance;
    [SerializeField] private float _blindChaseTime = 1f;
    
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
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
                transform.LookAt(player.position);   
            }
            yield return null;
        }
    }

    private bool CanSeePlayer()
    {
        Ray ray = new Ray(transform.position, (Player.instance.transform.position - transform.position).normalized);
        if (Physics.Raycast(ray, out RaycastHit hit, _chaseDistance) && hit.transform.gameObject.CompareTag("Player"))
        {
            return true;
        }
        return false;
    }

    public override void OnHit(int damage)
    {
        base.OnHit(damage);
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
