using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // ����¡���ع��ѧ 3 ��
    }

    void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Ŵ���ʹ�ѵ��
            Destroy(gameObject); // ����¡���ع�����ⴹ
        }
    }
}