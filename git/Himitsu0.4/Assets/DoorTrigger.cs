using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // เช็คว่าเป็นผู้เล่นหรือไม่
        {
            SceneManager.LoadScene("DemoScene"); // เปลี่ยนฉากเป็น DemoScene
        }
    }
}
