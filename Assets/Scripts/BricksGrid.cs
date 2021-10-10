using UnityEngine;

public class BricksGrid : MonoBehaviour
{
    [SerializeField] private Brick brick;
    [SerializeField] private Vector2 space;
    [SerializeField] private Texture2D[] images;

    private void Start()
    {
        SpawnNewGrid();
    }

    public void SpawnNewGrid()
    {
        var image = images[Random.Range(0, images.Length)];
        var trans = transform;

        var width = brick.Width + space.x;
        var height = brick.Height + space.y;

        var offsetX = image.width % 2 == 0 ? (1 - image.width) / 2f : -image.width / 2;
        var offsetY = image.height % 2 == 0 ? (1 - image.height) / 2f : -image.height / 2;

        for (var y = 0; y < image.height; y++)
        {
            for (var x = 0; x < image.width; x++)
            {
                var pixel = image.GetPixel(x, y);
                if (pixel.a == 0) continue;
                var spawnPosition = new Vector3(width * (x + offsetX), height * (y + offsetY)) + trans.position;
                var newBrick = Instantiate(brick, spawnPosition, Quaternion.identity, trans);
                newBrick.Setup(pixel.grayscale);
            }
        }
    }
}