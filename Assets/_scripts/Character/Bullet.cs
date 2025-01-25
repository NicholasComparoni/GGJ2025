using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public Vector3 direction;

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
        if (other.gameObject.GetComponent<Character>() && other.gameObject.tag == "Enemy")
        {
           other.gameObject.GetComponent<Character>().OnHit(damage);
           
        }
        Destroy(gameObject);
    }
}