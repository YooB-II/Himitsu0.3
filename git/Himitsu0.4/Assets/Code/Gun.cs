using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire button pressed!");
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Spawning bullet!");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        if (bullet == null)
        {
            Debug.LogError("bulletPrefab is null! Check the settings in the Inspector.");
            return;
        }

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found on the bullet!");
            return;
        }

        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}