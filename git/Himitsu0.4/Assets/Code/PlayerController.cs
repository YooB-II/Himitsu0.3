using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 0f;

    void Update()
    {
        float move = Input.GetAxis("Vertical"); // �� W ���� S
        speed = Mathf.Abs(move) * 3f; // ��Ѻ��� Speed

        animator.SetFloat("Speed", speed);
    }
}