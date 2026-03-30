using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float speed = 2f;
    public float chunkLength = 18f; // Width of your background image
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        // Move the background to the left based on speed
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Move the background back to loop when it passes the chunk length
        if (transform.position.x <= startX - chunkLength)
        {
            transform.position = new Vector2(transform.position.x + (chunkLength * 2f), transform.position.y);
        }
    }
}