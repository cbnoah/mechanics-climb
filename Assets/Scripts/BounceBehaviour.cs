using UnityEngine;

public class BounceBehaviour : MonoBehaviour
{
    [SerializeField] float bounceForce = 10f;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            MovementBehavior movement = other.gameObject.GetComponent<MovementBehavior>();
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (movement != null && movement.IsFalling() && rb != null) {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
                Debug.Log("Bounce! New velocity: " + rb.linearVelocity);
                movement.SetFalling(false);
            }
        }
    }
    
}
