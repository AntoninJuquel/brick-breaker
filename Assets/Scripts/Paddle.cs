using UnityEngine;

public class Paddle : MonoBehaviour, ISurface
{
    [SerializeField] private float speed, maxBounceAngle;
    private float _horizontalInput;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        var newPosition = _transform.position + Vector3.right * (_horizontalInput * speed * Time.fixedDeltaTime);
        if (Mathf.Abs(newPosition.x) > 25f) return;
        _transform.position = newPosition;
    }

    public void OnHit(Vector2 contactPoint, Rigidbody2D rb, Collider2D col, float bounciness)
    {
        rb.velocity = (rb.velocity.normalized + Vector2.right * _horizontalInput).normalized * bounciness;
    }
}