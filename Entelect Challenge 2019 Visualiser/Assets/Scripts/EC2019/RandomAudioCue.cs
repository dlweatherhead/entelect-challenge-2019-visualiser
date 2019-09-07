using UnityEngine;

namespace EC2019 {
    [RequireComponent(typeof(AudioSource))]
    public class RandomAudioCue : MonoBehaviour {
        public AudioClip[] clips;
    
        void Start() {
            var selectedAudio = Random.Range(0, clips.Length);
            var audioSource = GetComponent<AudioSource>();
            audioSource.clip = clips[selectedAudio];
            audioSource.Play();
        }
    }
}
