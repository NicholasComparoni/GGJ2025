using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Vector3 direction;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject _bulletParticle;
    [SerializeField] private bool isPlayer;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        Movement();
        //LookAtPlayer();
    }

    private void Movement()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                if (other.gameObject.GetComponent<Character>())
                {
                    other.gameObject.GetComponent<Character>().OnHit(damage);
                }
                Instantiate(_bulletParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
        {
            if (!other.gameObject.CompareTag("Enemy"))
            {
                if (other.gameObject.GetComponent<Character>())
                {
                    other.gameObject.GetComponent<Character>().OnHit(damage);
                }
                Instantiate(_bulletParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }
}