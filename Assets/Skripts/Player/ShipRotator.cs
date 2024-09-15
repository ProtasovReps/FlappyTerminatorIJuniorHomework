using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationAngle;
    [SerializeField] private float _rotationVelocityY;

    private Quaternion _startRotation;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startRotation = transform.rotation;
        _minRotation = Quaternion.Euler(0f, 0f, -_rotationAngle);
        _maxRotation = Quaternion.Euler(0f, 0f, _rotationAngle);
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y <= -_rotationVelocityY)
            Rotate(_minRotation);
        else if (_rigidbody.velocity.y <= _rotationVelocityY)
            Rotate(_startRotation);
        else if (_rigidbody.velocity.y >= _rotationVelocityY)
            Rotate(_maxRotation);
    }

    private void Rotate(Quaternion targetRotation)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * _rotationSpeed);
    }
}