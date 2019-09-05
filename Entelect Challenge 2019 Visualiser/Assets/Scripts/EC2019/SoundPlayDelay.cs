using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayDelay : MonoBehaviour {

    public AudioClip[] clipArray;
    
    public float delay;

    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        var selectedClip = Random.Range(0, clipArray.Length);
        audioSource.clip = clipArray[selectedClip];
        StartCoroutine(PlaySound());
    }

    IEnumerator PlaySound() {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}