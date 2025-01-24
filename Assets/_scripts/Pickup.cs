using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Pickup : MonoBehaviour
{
    [Header("Stats Modifiers")]
    [SerializeField] private Stat _target;
    [SerializeField] private float _amount;
    
    [Header("Type")] 
    [SerializeField] private bool _isWeapon;
    
    private SphereCollider _collider;
    
    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();
    }

    private void Start()
    {
        //Non deve rompere il cazzo al movimento di nessuno
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isWeapon)
        {
            PickupWeapon(other);
            return;
        }
        PickupItem(other);
    }

    private void PickupWeapon(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            //Do weapon stuff
            Destroy(gameObject);
        }
    }

    private void PickupItem(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            //UpdateStats(_statTarget, _statValue)
            Destroy(gameObject);
        }
    }
}
