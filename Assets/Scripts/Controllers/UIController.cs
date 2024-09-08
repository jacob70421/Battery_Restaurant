using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField] GameObject menu;
    [Header("Sliders")]
    public Slider soundSlider;
    public Slider musicSlider;
    [Header("Text Mesh Pro UGUI")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreInGameText;
    [SerializeField] TextMeshProUGUI scoreInMenuText;
    [SerializeField] TextMeshProUGUI highestScoreText;
    [Header("Scripts")]
    [SerializeField] GameController gameController;
    [SerializeField] AudioController audioController;
    private void Start() {
        if (PlayerPrefs.GetInt("FirstTimePlaying") == 1) {
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        audioController.UpdateSoundVolume();
        audioController.UpdateMusicVolume();
        soundSlider.onValueChanged.AddListener(delegate { audioController.UpdateSoundVolume(); });
        musicSlider.onValueChanged.AddListener(delegate { audioController.UpdateMusicVolume(); });
        UpdateHighestScoreText();
        UpdateScoreInMenuText();
        PlayerPrefs.SetInt("FirstTimePlaying", 1);
    }
    private void Update() {
        if (gameController.gameStarted) {
            UpdateTimerText();
        }
    }
    public void UpdateTimerText() {
        timerText.text = decimal.Round((decimal)gameController.timer, 2).ToString();
        if (gameController.timer < 10) {
            timerText.color = Color.red;
        } else {
            timerText.color = Color.white;
        }
    }
    public void UpdateScoreInGameText() {
        scoreInGameText.text = gameController.score.ToString();
        if (gameController.score > PlayerPrefs.GetInt("Score")) {
            scoreInGameText.color = Color.yellow;
        } else {
            scoreInGameText.color = Color.white;
        }
    }
    public void UpdateScoreInMenuText() {
        scoreInMenuText.text = "Latest score: " + gameController.score;
    }
    public void UpdateHighestScoreText() {
        highestScoreText.text = "Highest score: " + PlayerPrefs.GetInt("Score");
    }
    public void SwitchMenu(bool yes) {
        if (yes) {
            menu.SetActive(true);
        } else {
            menu.SetActive(false);
        }
    }
    public void StartGame() {
        gameController.StartGame();
    }
    public void ExitGame() {
        Application.Quit();
    }
}
