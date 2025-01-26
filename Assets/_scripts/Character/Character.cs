using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    [Header("Character Stats")] [SerializeField]
    protected int _health;

    public virtual int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    [SerializeField] protected int _maxHealth;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected int _atkDamage;

    [Header("Prefabs")] [SerializeField] protected Bullet _bulletPrefab;

    //References
    protected Rigidbody _rb;
    protected CapsuleCollider _bodyCollisionIdentifier;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _bodyCollisionIdentifier = GetComponent<CapsuleCollider>();
    }

    protected void Start()
    {
        Health = _maxHealth;
    }

    public virtual void OnHit(int damage)
    {
        _health -= damage;
        Player.HealthChanged.Invoke(_health);
        Debug.Log("Preso " + damage + " da bullet, mi rimane " + _health);
    }

    public virtual void Die()
    {
        //Do stuffs
        Destroy(gameObject);
    }
}