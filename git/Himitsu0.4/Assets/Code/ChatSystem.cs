using UnityEngine;
using UnityEngine.UI;

public class ChatSystem : MonoBehaviour
{
    public InputField chatInput;
    public Text chatDisplay; 
    public ScrollRect scrollRect;

    void Start()
    {
        chatInput.onEndEdit.AddListener(SendMessage);
    }

    void SendMessage(string message)
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            chatDisplay.text += "\n" + message; 
            chatInput.text = ""; 

            Canvas.ForceUpdateCanvases(); 
            scrollRect.verticalNormalizedPosition = 0f;
        }
    }
}