using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public static List<Gravity> objectsWithGravity = new List<Gravity>();
    public Rigidbody rb;
    public bool isOrbiting = false;
    public float initialOrbitSpeed = 5f;

    const float G = 0.00674f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        objectsWithGravity.Add(this);

        if (isOrbiting && objectsWithGravity.Count > 1)
        {
            Gravity centralBody = objectsWithGravity[0];
            Vector3 orbitDirection = Vector3.Cross(Vector3.up, (rb.position - centralBody.rb.position).normalized);
            rb.linearVelocity = orbitDirection * initialOrbitSpeed;
        }
    }

    private void FixedUpdate()
    {
        foreach (Gravity obj in objectsWithGravity)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }

    void Attract(Gravity other)
    {
        Rigidbody rbOther = other.rb;
        Vector3 direction = rb.position - rbOther.position;
        float distance = direction.magnitude;

        if (distance == 0) return;

        float forceMagnitude = G * (rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);
        Vector3 force = forceMagnitude * direction.normalized;

        rbOther.AddForce(force);
    }

    private void OnDestroy()
    {
        objectsWithGravity.Remove(this);
    }
}
