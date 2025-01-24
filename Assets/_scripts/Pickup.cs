using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(SphereCollider))]
public class Pickup : MonoBehaviour
{
    [FormerlySerializedAs("_statTarget")]
    [Header("Stats Modifiers")]
    [SerializeField] private Stat _target;
    [SerializeField] private float _amount;
    
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
        if (other.gameObject.CompareTag("Player"))
        {
            //UpdateStats(_statTarget, _statValue)
            Destroy(gameObject);
        }
    }
}
