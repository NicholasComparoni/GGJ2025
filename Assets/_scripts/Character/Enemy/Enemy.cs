using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Enemy : Character
{
    [Header("Agent")] [SerializeField] private float _stopDistance;
    [SerializeField] private float _acceleration;
    [Header("Enemy")] [SerializeField] private float _chaseDistance;
    [SerializeField] private float _blindChaseTime = 1f;
    [SerializeField] private float _atkRange;
    [SerializeField] private bool isWall;

    [SerializeField] private Transform _bulletSpawnPoint;

    [SerializeField] protected GameObject[] OldGuys = new GameObject[3];


    private NavMeshAgent _agent;
    private Animator _animator;
    private float elapsedTime;

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

    public void Shoot()
    {
        if (elapsedTime >= _fireRate &&
            _atkRange >= Vector3.Distance(transform.position, Player.instance.transform.position))
        {
            _animator.SetTrigger("Attack");
            var instanceOfBullet =
                Instantiate(_bulletPrefab, _bulletSpawnPoint.position, Quaternion.identity);
            instanceOfBullet.damage = _atkDamage;
            instanceOfBullet.direction = transform.forward;
            instanceOfBullet.transform.rotation = transform.rotation;
            elapsedTime = 0;
        }

        if (elapsedTime == 0)
        {
            StartCoroutine(ResetFireTime());
        }
    }

    private IEnumerator ResetFireTime()
    {
        while (true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= _fireRate)
            {
                break;
            }

            yield return null;
        }
    }

    private IEnumerator ChasePlayer()
    {
        float chaseTimer = _blindChaseTime + 0.1f;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (!isWall)
        {
            while (true)
            {
                transform.LookAt(player.position);
                if (!CanSeePlayer())
                {
                    chaseTimer += Time.deltaTime;
                }
                else
                {
                    chaseTimer = 0;
                    Shoot();
                }

                if (chaseTimer < _blindChaseTime)
                {
                    _agent.SetDestination(player.position);
                }

                yield return null;
            }
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
            if (!isWall)
            {
                Vector3 OffSet = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                int randomNumber = UnityEngine.Random.Range(0, OldGuys.Length);
                var oldGuy = Instantiate(OldGuys[randomNumber], OffSet, Quaternion.identity, parent: null);
                oldGuy.transform.localScale = new Vector3(4f, 4f, 4f);
            }

            Die();
        }
    }
}