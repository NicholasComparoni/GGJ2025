using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] protected int _movementSpeed;
    [SerializeField] public int fireRate;
    [SerializeField] public Rigidbody _rb;
    [SerializeField] protected Collider _bodyCollisionIdentifier;
}