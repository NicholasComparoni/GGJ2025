using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Character : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected int _health;
    [SerializeField] protected int _movementSpeed;
    [SerializeField] protected int _fireRate;
    //References
    protected Rigidbody _rb;
    protected Collider _bodyCollisionIdentifier;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _bodyCollisionIdentifier = GetComponent<Collider>();
    }
}