using UnityEngine;
using UnityEngine.InputSystem;

public class MovementBehavior : MonoBehaviour
{
    InputAction moveAction;
    InputAction sprintAction;
    [SerializeField] float moveSpeed = 12f;
    private Rigidbody2D _rigidBody;
    private bool falling;
    [SerializeField] private Camera _camera;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite fallingSprite;
    [SerializeField] private Sprite jumpingSprite;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip springSound;


    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        falling = true;
        _spriteRenderer.sprite = idleSprite;
    }

    void Start()
    {
        GameManager.Instance.OnGameOver.AddListener(SetVelocityNull);
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
        if (GameManager.Instance.GetIsPlaying())
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();
            bool isSprinting = sprintAction.ReadValue<float>() > 0.5f;
            transform.Translate(Vector3.right * (moveValue.x * moveSpeed * Time.deltaTime * (isSprinting ? 2f : 1f)));
            if (_rigidBody.linearVelocity.y < 0)
            {
                SetFalling(true);
            }

            IsUnderTheCamera();
        }
    }

    public bool IsFalling()
    {
        return falling;
    }

    private void SpecialSound(string type)
    { 
        Debug.Log("cette plateforme est de type : " + type);
        if (type.Equals("SpringPlateforme(Clone)"))
        {
            Debug.Log("Spring");
            SoundFXManager.Instance.PlaySound(springSound, transform, 0.1f);
        }
    }

    public void SetFalling(bool value, string type = "")
    {
        if (falling && !value)
        {
            if (!type.Equals("Plateforme(Clone)")) SpecialSound(type);

            SoundFXManager.Instance.PlaySound(jumpSound, transform, 0.1f);
        }

        falling = value;
        _spriteRenderer.sprite = falling ? fallingSprite : jumpingSprite;
    }

    private void SetVelocityNull()
    {
        Debug.Log("SetVelocityNull");
        _rigidBody.linearVelocity = new Vector2(0, 0);
    }

    public void IsUnderTheCamera()
    {
        Vector3 bottomEdge = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, _camera.nearClipPlane));
        float destroyY = bottomEdge.y - 1f;
        if (_rigidBody.transform.position.y < destroyY)
        {
            SetFalling(false);
            GameManager.Instance.GameOver();
        }
    }
}