using EC2019.Utility;
using UnityEngine;

namespace EC2019 {
    [RequireComponent(typeof(AudioSource))]
    public class RandomClipPlayer : MonoBehaviour {
        public AudioClip[] clips;
    
        void Start() {
            var audioSource = GetComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }

        public void PlayRandomSound(int PlayerId) {
            var selectedAudio = Random.Range(0, clips.Length);
            var audioSource = GetComponent<AudioSource>();

            if (PlayerId == Constants.PlayerA.Number) {
                audioSource.panStereo = -0.75f;
            } else if (PlayerId == Constants.PlayerB.Number) {
                audioSource.panStereo = 0.75f;
            }
            else {
                audioSource.panStereo = 0.75f;
            }

            audioSource.clip = clips[selectedAudio];
            audioSource.Play();
        }
    }
}
