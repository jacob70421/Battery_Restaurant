using UnityEngine;

public class AudioPlayScript : MonoBehaviour {
    [SerializeField] AudioSource audioSource;
    private void Start() {
        audioSource.Play();
    }
    private void Update() {
        if (!audioSource.isPlaying) {
            Destroy(gameObject);
        }
    }
}
