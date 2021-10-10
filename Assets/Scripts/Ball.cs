using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public static event Action OnBallDestroy;
    private static int _amount;
    public static bool NoBall => _amount == 0;
    [SerializeField] private float bounciness;
    private Rigidbody2D _rb;
    private Collider2D _col;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _rb.velocity = (NoBall ? new Vector2(Random.Range(-1f, 1f), -1f) : Random.insideUnitCircle).normalized * bounciness;
        _amount++;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var surface = other.gameObject.GetComponent<ISurface>();
        surface?.OnHit(other.GetContact(0).point, _rb, _col, bounciness);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _rb.velocity = _rb.velocity.normalized * bounciness;
    }

    private void OnBecameInvisible()
    {
        Destroy();
    }

    private void Destroy()
    {
        _amount--;
        Destroy(gameObject);
        OnBallDestroy?.Invoke();
    }
}