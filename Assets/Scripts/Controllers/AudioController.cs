using UnityEngine;

public class AudioController : MonoBehaviour {
    [Header("Misc Settings")]
    [SerializeField] Transform parent;
    [Header("Sounds Settings")]
    [Range(0f, 1f)]
    public float soundVolume;
    [SerializeField] AudioClip[] clips;
    [SerializeField] GameObject audioSource;
    [Header("Music Settings")]
    [Range(0f, 1f)]
    public float musicVolume;
    [SerializeField] AudioSource musicSource;
    [Header("Script Settings")]
    [SerializeField] UIController uiController;
    public void CreateSoundSource(Vector2 position, int clip) {
        var newAudioSource = Instantiate(audioSource, position, Quaternion.identity, parent);
        newAudioSource.GetComponent<AudioSource>().volume = soundVolume;
        newAudioSource.GetComponent<AudioSource>().clip = clips[clip];
    }
    public void MuteMusic(bool yes) {
        if (yes) {
            musicSource.mute = true;
        } else {
            musicSource.mute = false;
        }
    }
    public void UpdateMusicVolume() {
        musicVolume = uiController.musicSlider.value;
        musicSource.volume = musicVolume;
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
    public void UpdateSoundVolume() {
        soundVolume = uiController.soundSlider.value;
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }
}
