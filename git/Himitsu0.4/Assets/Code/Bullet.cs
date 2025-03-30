using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // ทำลายกระสุนหลัง 3 วิ
    }

    void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // ลดเลือดศัตรู
            Destroy(gameObject); // ทำลายกระสุนเมื่อโดน
        }
    }
}