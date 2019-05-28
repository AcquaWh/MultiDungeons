using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voces : MonoBehaviour
{
    [SerializeField]
    AudioClip VocesClips;
    private float volLowRange = .5f;
    private float volHighRange = 3.0f;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        float vol = Random.Range(volLowRange, volHighRange);
        audioSource.PlayOneShot(VocesClips, vol);
        Destroy(this);
    }
}
