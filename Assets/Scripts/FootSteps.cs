using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    AudioClip grassClips;
    private float volLowRange = .5f;
    private float volHighRange = 3.0f;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSource.Stop();
    }
    private void Step()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        audioSource.PlayOneShot(grassClips,vol);
 
    }

}