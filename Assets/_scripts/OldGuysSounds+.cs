using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class OldGuysSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int randomNumber = UnityEngine.Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[randomNumber]);
        Destroy(this, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}