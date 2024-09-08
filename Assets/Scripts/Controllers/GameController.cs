using UnityEngine;

public class GameController : MonoBehaviour {
    [Header("Spawn Settings")]
    [SerializeField] SpawningArea spawningAreaScript;
    [SerializeField] float spawnTimerDefault = 1.0f;
    [HideInInspector] public float spawnTimer = 1.0f;
    [Header("Timer Settings")]
    [SerializeField] float timerDefault = 30.0f;
    [HideInInspector] public float timer = 30.0f;
    [Header("Battery Settings")]
    [SerializeField] GameObject batteryPrefab;
    [SerializeField] Transform batteryParent;
    [Header("Scripts")]
    [SerializeField] UIController uiController;
    [SerializeField] AudioController audioController;
    [HideInInspector] public int score = 0;
    [HideInInspector] public bool gameStarted = false;
    private void Update() {
        if (gameStarted) {
            if (timer <= 0) {
                GameEnd();
            } else {
                timer -= Time.deltaTime;
                spawnTimer -= Time.deltaTime;
            }
            if (spawnTimer <= 0) {
                spawningAreaScript.SpawnPeople();
                spawnTimer = spawnTimerDefault;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                audioController.CreateSoundSource(transform.position, 1);
                Instantiate(batteryPrefab, mousePos, Quaternion.identity, batteryParent);
            }
        }
    }
    public void AddToScore() {
        score += 1;
    }
    public void StartGame() {
        gameStarted = true;
        timer = timerDefault;
        score = 0;
        audioController.MuteMusic(true);
        uiController.SwitchMenu(false);
        uiController.UpdateScoreInGameText();
    }
    private void GameEnd() {
        gameStarted = false;
        PlayerPrefs.SetInt("Score", score);
        uiController.UpdateHighestScoreText();
        uiController.UpdateScoreInMenuText();
        audioController.MuteMusic(false);
        uiController.SwitchMenu(true);
    }
}
