using UnityEngine;

public class Grass : MonoBehaviour
{
    public float swayAngle = 2f;
    public float swaySpeed = 1f;
    private Quaternion startRotation;
    private float randomOffset;

    void Start()
    {
        startRotation = transform.localRotation;
        randomOffset = Random.Range(0f, 10f);
    }

    void Update()
    {
        float angle = Mathf.Sin(Time.time * swaySpeed + randomOffset) * swayAngle;
        transform.localRotation = startRotation * Quaternion.Euler(0f, 0f, angle);
    }
}