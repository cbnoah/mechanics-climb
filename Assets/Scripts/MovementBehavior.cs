using UnityEngine;
using UnityEngine.InputSystem;

public class MovementBehavior : MonoBehaviour
{
    InputAction moveAction;
    InputAction sprintAction;
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D _rigidBody;
    private bool falling;

     void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        falling = true;
    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        if (moveAction == null)
        {
            Debug.LogError("Move action not found in Input System.");
        }

        sprintAction = InputSystem.actions.FindAction("Sprint");
        if (sprintAction == null)
        {
            Debug.LogError("Sprint action not found in Input System.");
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        bool isSprinting = sprintAction.ReadValue<float>() > 0.5f;
        Vector3 velocity = _rigidBody.linearVelocity;
        velocity.x = moveValue.x * moveSpeed * (isSprinting ? 2f : 1f);
        _rigidBody.linearVelocity = velocity;
        if (velocity.y < 0)
        {
            falling = true;
        }
    }

    public bool IsFalling()
    {
        return falling;
    }

    public void SetFalling(bool value)
    {
        falling = value;
    }
}
