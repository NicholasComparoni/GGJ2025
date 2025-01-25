using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Character : MonoBehaviour
{
    [Header("Character")]
    [SerializeField] protected int _health;
    [SerializeField] protected int _movementSpeed;
    [SerializeField] protected int _fireRate;
    //References
    protected Rigidbody _rb;
    protected CapsuleCollider _bodyCollisionIdentifier;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _bodyCollisionIdentifier = GetComponent<CapsuleCollider>();
    }
}