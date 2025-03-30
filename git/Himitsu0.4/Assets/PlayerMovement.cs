using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float iceFriction = 0.98f; // ��Ҥ������ ������ 1 ������
    public float acceleration = 10f;

    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // ��ͧ�ѹ�����ع����ФüԴ����
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(moveX, 0, moveZ).normalized;
        moveDirection = Vector3.Lerp(moveDirection, inputDirection, acceleration * Time.deltaTime);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x * iceFriction, rb.linearVelocity.y, rb.linearVelocity.z * iceFriction); // Ŵ��������ŧ������� (����͹���)
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Acceleration);
    }
}