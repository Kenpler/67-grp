using UnityEngine;

public class CameraBreathing : MonoBehaviour
{
    public float amplitude = 0.1f; // hareketin yuksekligi
    public float frequency = 1f;   // Hareketin hizi

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);
    }
}