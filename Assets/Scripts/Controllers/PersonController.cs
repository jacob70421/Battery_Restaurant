using UnityEngine;
using UnityEngine.Events;

public class PersonController : MonoBehaviour {
    [Header("Person Settings")]
    [SerializeField] int hunger = 1;
    [SerializeField] int pointsOnFeed = 1;
    [SerializeField] float despawnTime = 3.0f;
    public UnityEvent scoreAdd;
    private void Start() {
        scoreAdd.AddListener(GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().AddToScore);
        scoreAdd.AddListener(GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>().UpdateScoreInGameText);
    }
    private void Update() {
        if (despawnTime <= 0) {
            Destroy(gameObject);
        } else {
            despawnTime -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Battery")) {
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("AudioController").GetComponent<AudioController>().CreateSoundSource(transform.position, 0);
            hunger--;
            if (hunger == 0) {
                for (int i = 0; i < pointsOnFeed; i++) {
                    scoreAdd.Invoke();
                }
                Destroy(gameObject);
            }
        }
    }
}
