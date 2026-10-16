using UnityEngine;

public class Bullets : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Timer timer = FindFirstObjectByType<Timer>();

            if (timer != null)
            {
                timer.TargetHit();
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}