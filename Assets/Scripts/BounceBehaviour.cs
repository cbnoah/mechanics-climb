using JetBrains.Annotations;
using UnityEngine;

public class BounceBehaviour : MonoBehaviour
{
    [SerializeField] float bounceForce = 15f;
    [SerializeField] [CanBeNull] AudioClip[] breakableBounceSounds;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MovementBehavior movement = other.gameObject.GetComponent<MovementBehavior>();
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (movement == null || !movement.IsFalling() || rb == null) return;
            rb.linearVelocity = Vector2.up * bounceForce;
            Debug.Log("Bounce! New velocity: " + rb.linearVelocity);
            movement.SetFalling(false, gameObject.ToString());
        }

        if (gameObject.ToString().Contains("Breakable"))
        {
            SoundFXManager.Instance.PlaySound(breakableBounceSounds[Random.Range(0, breakableBounceSounds.Length-1)], transform, 0.1f);
            gameObject.SetActive(false);
        }
    }
}