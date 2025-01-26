using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]
public class Pickup : MonoBehaviour
{
    [Header("Stats Modifiers")] [SerializeField]
    private Stat _target;

    [SerializeField] private float _amount;

    [Header("Idle Animation")] [SerializeField]
    private float _posDeltaY;

    [SerializeField] private float _posSpeed;
    [SerializeField] [Range(1, 20)] private float _rotSpeed;

    [Header("Pickup Feedbacks")] 
    //[SerializeField] private GameObject feedbacks;

    [SerializeField] private GameObject _ammoFeedback;
    [SerializeField] private GameObject _healthFeedback;

    private const int ROT_SPEED_MULTIPLIER = 20;

    private SphereCollider _collider;

    private void Awake()
    {
        _collider = GetComponent<SphereCollider>();

    }

    private void Start()
    {
        //Non deve rompere il cazzo al movimento di nessuno
        _collider.isTrigger = true;
        _ammoFeedback = FindFirstObjectByType<AmmoFeedbackIdentifier>().gameObject;
        _healthFeedback = FindFirstObjectByType<HealthFeedbackIdentifier>().gameObject;
        StartCoroutine(Idle());
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (_isWeapon)
        // {
        //     PickupWeapon(other);
        //     return;
        // }
        PickupItem(other);
    }


    private void PickupItem(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            var feedbackHandler = coll.GetComponent<PickupFeedbackHandler>();
            if (feedbackHandler != null)
            {
                if (_target == Stat.HEALTH)
                    feedbackHandler.ShowFeedback(_healthFeedback);
                else if (_target == Stat.AMMO)
                    feedbackHandler.ShowFeedback(_ammoFeedback);
            }

            Destroy(gameObject);
        }
    }

    private IEnumerator Idle()
    {
        float currentPosY = 0;
        bool animDirection = false;
        while (true)
        {
            transform.Rotate(Vector3.up * (_rotSpeed * Time.deltaTime * ROT_SPEED_MULTIPLIER));
            if (!animDirection)
            {
                transform.localPosition += Vector3.up * (_posSpeed * Time.deltaTime);
                currentPosY += _posSpeed * Time.deltaTime;
                if (currentPosY >= _posDeltaY)
                {
                    animDirection = true;
                }
            }
            else
            {
                transform.localPosition -= Vector3.up * (_posSpeed * Time.deltaTime);
                currentPosY -= _posSpeed * Time.deltaTime;
                if (currentPosY <= 0)
                {
                    animDirection = false;
                }
            }

            yield return null;
        }
    }

    // private void PickupWeapon(Collider coll)
    // {
    //     if (coll.gameObject.CompareTag("Player"))
    //     {
    //         //Do weapon stuff
    //         Destroy(gameObject);
    //     }
    // }
}