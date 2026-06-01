using UnityEngine;
using UnityEngine.InputSystem;

public class MovementBehavior : MonoBehaviour
{
    InputAction moveAction;
    InputAction sprintAction;
    [SerializeField] float moveSpeed = 12f;
    private Rigidbody2D _rigidBody;
    private bool falling;
    private Camera _camera;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
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
        if (!IsUnderTheCamera())
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();
            bool isSprinting = sprintAction.ReadValue<float>() > 0.5f;
            // Vector3 velocity = _rigidBody.linearVelocity;
            // velocity.x = moveValue.x * moveSpeed * (isSprinting ? 2f : 1f) * Time.fixedDeltaTime;
            // _rigidBody.linearVelocity = velocity;
            transform.Translate(Vector3.right * moveValue.x * moveSpeed * Time.deltaTime * (isSprinting ? 2f : 1f));
            if (_rigidBody.linearVelocity.y < 0)
            {
                falling = true;
            }
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

    public bool IsUnderTheCamera()
    {
        Vector3 bottomEdge = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, _camera.nearClipPlane));
        float destroyY = bottomEdge.y - 1f;
        if (_rigidBody.transform.position.y < destroyY)
        {
            Debug.Log("Under the camera");
            SetFalling(false);
            return true;
        }

        return false;
    }
}