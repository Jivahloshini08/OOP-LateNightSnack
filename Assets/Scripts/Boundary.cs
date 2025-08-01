using UnityEngine;

public class Boundary : MonoBehaviour
{
    private float objectWidth;
    private float objectHeight;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    void Start()
    {
        objectWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        Camera cam = Camera.main;

        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.transform.position.z * -1));
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z * -1));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, minBounds.x + objectWidth, maxBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, minBounds.y + objectHeight, maxBounds.y - objectHeight);

        transform.position = viewPos;
    }
}
