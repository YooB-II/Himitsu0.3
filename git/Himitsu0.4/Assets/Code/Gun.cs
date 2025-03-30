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
            Debug.Log("กดปุ่มยิงแล้ว!"); // เช็คว่ากดปุ่มได้ไหม
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("สร้างกระสุน!");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        if (bullet == null)
        {
            Debug.LogError("bulletPrefab เป็น null! ตรวจสอบการตั้งค่าใน Inspector");
            return;
        }

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("ไม่มี Rigidbody บนกระสุน!");
            return;
        }

        rb.linearVelocity = firePoint.forward * bulletSpeed;
    }
}