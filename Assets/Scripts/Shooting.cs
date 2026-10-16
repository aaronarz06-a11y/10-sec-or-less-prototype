using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30f;

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(100f);
        }

        transform.LookAt(targetPoint);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(targetPoint);
        }
    }

    void Shoot(Vector3 targetPoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);

        Vector3 direction = (targetPoint - bulletSpawn.position).normalized;

        bullet.transform.forward = direction;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }
}