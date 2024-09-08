using UnityEngine;

public class SpawningArea : MonoBehaviour {
    [Header("Spawn Settings")]
    [SerializeField] Transform gameObjectsParent;
    [SerializeField] GameObject[] gameObjectsToSpawn;
    [SerializeField] int maxAmountToSpawn;
    float positionX;
    float positionY;
    public void SpawnPeople() {
        for (int i = 0; i < RandomAmountToSpawn(); i++) {
            SpawnRandomPerson();
        }
    }
    private void SpawnRandomPerson() {
        positionX = Random.Range(-1 * gameObject.transform.localScale.x / 2, gameObject.transform.localScale.x / 2 + 1);
        positionY = Random.Range(-1 * gameObject.transform.localScale.y / 2, gameObject.transform.localScale.y / 2 + 1);
        Instantiate(gameObjectsToSpawn[Random.Range(0, gameObjectsToSpawn.Length)], new Vector3(positionX, positionY, 0), Quaternion.identity, gameObjectsParent);
    }
    private int RandomAmountToSpawn() {
        return Random.Range(1, maxAmountToSpawn + 1);
    }
    private void OnDrawGizmos() {
        Gizmos.color = new Color(0, 0, 1, 0.4f);
        Gizmos.DrawCube(Vector3.zero, new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, 0));
    }
}
