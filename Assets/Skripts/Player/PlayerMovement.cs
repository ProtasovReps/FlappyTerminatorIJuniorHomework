using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;

    private Rigidbody2D _rigidbody;
    private Vector2 _startPosition;

    public void Reset()
    {
        transform.SetPositionAndRotation(_startPosition, Quaternion.identity);
        _rigidbody.velocity = Vector2.zero;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _rigidbody.gravityScale = _gravityScale;
    }

    private void OnEnable()
    {
        _inputReader.JumpButtonPressed += Move;
    }

    private void OnDisable()
    {
        _inputReader.JumpButtonPressed -= Move;
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(0f, _jumpForce);
    }
}