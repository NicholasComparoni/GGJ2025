using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Character : MonoBehaviour
{
    [Header("Character Stats")]
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected int _atkDamage;
    protected int _health;
    [Header("Prefabs")]
    [SerializeField] protected Bullet _bulletPrefab;
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
        _health = _maxHealth;
    }

    public virtual void OnHit(int damage)
    {
        _health -= damage;
        Debug.Log("Preso " + damage + " da bullet, mi rimane " + _health);
    }

    public virtual void Die()
    {
        //Do stuffs
        Destroy(gameObject);
    }
}