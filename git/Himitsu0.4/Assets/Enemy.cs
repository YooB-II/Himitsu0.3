using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f; // ��˹����ʹ�٧�ش
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // ��駤���������
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " ⴹ����! ���ʹ�����: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " ���!");
        Destroy(gameObject); // ����µ���ͧ
    }
}
