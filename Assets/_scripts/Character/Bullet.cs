using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Vector3 direction;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject _bulletParticle;


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

    // private void LookAtPlayer()
    // {
    //     _bulletSprite.transform.LookAt(Player.instance.transform.position);
    // }

    private void OnTriggerEnter(Collider other)
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
}