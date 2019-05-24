using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.ControllerSystem;
using UnityEngine.SceneManagement;
public class Button : MonoBehaviour
{
    public AudioClip buttonSound;
    private float throwSpeed = 2000f;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    IEnumerator<WaitForSeconds> checkButton;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
  
        if (ControllerSystem.Start1)
        {
            Debug.Log("Pasa");
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(buttonSound, vol);
            checkButton = CheckButton();
            StartCoroutine(checkButton);
        }
    }
    public IEnumerator<WaitForSeconds> CheckButton()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Menu");
    }
}
