using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f; // กำหนดเลือดสูงสุด
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่าเริ่มต้น
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " โดนโจมตี! เลือดเหลือ: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " ตาย!");
        Destroy(gameObject); // ทำลายตัวเอง
    }
}
