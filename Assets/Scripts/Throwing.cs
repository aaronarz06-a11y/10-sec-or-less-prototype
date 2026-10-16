using UnityEngine;
using System.Collections;

public class Throwing : MonoBehaviour
{
    public float throwDelay = 1f;
    public float throwForce = 8f;
    public float upwardForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        StartCoroutine(ThrowAfterDelay());
    }

    IEnumerator ThrowAfterDelay()
    {
        yield return new WaitForSeconds(throwDelay);

        rb.useGravity = true;

        Throw();
    }

    void Throw()
    {
        Vector3 throwDirection = transform.forward * throwForce;

        throwDirection.y = upwardForce;

        rb.AddForce(throwDirection, ForceMode.Impulse);
    }
}