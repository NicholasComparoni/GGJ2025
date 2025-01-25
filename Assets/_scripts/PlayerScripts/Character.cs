using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int _movementSpeed;
    [SerializeField] protected int fireRate;
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected Collider _bodyCollisionIdentifier;
}