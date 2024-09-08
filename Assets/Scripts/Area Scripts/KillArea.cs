using UnityEngine;

public class KillArea : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Battery")) {
            Destroy(collision.gameObject);
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = new Color(1, 0, 0, 0.4f);
        Gizmos.DrawCube(transform.position, new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, 0));
    }
}
