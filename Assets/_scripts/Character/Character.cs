using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Character : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected int _health;
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected int _dmg;
    [SerializeField] protected Bullet _bulletPrefab;
    //References
    protected Rigidbody _rb;
    protected CapsuleCollider _bodyCollisionIdentifier;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _bodyCollisionIdentifier = GetComponent<CapsuleCollider>();
    }
}