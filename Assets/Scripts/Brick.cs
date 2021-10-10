using System;
using UnityEngine;

public class Brick : MonoBehaviour, ISurface
{
    public static event Action OnBrickBreak;
    private static int _amount;
    public static bool NoBrick => _amount == 0;

    [SerializeField] private Sprite[] sprites;
    public int Width => (int) sprites[0].bounds.size.x;
    public int Height => (int) sprites[0].bounds.size.y;

    private int _health;
    private bool _unbreakable;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public void Setup(float health)
    {
        _unbreakable = health == 0;
        _health = (int) (health * (sprites.Length - 1));
        _sr.sprite = sprites[_health];
        _amount++;
    }

    public void OnHit(Vector2 contactPoint, Rigidbody2D rb, Collider2D col, float bounciness)
    {
        if (_unbreakable) return;
        _health--;

        if (_health <= 0)
        {
            Break();
            return;
        }

        _sr.sprite = sprites[_health];
    }

    private void Break()
    {
        _amount--;
        gameObject.SetActive(false);
        OnBrickBreak?.Invoke();
    }
}