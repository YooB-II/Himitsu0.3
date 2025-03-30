using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ������繼������������
        {
            SceneManager.LoadScene("DemoScene"); // ����¹�ҡ�� DemoScene
        }
    }
}
