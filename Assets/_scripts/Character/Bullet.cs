using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Vector3 direction;
    [SerializeField] private float lifeTime;


    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.GetComponent<Character>())
            {
                other.gameObject.GetComponent<Character>().OnHit(damage);
            }

            Destroy(gameObject);
        }
    }
}