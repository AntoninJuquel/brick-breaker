using UnityEngine;

public interface ISurface
{
    public void OnHit(Vector2 contactPoint, Rigidbody2D rb, Collider2D col, float bounciness);
}

public static class Utilities
{
    public static int Wrap(int input, int min, int max) => input < min ? max - (min - input) % (max - min) : min + (input - min) % (max - min);
}