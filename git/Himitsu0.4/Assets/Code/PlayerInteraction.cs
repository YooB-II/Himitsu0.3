using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))  
        {
            dialogueManager.StartDialogue();
        }

        if (Input.GetKeyDown(KeyCode.F))  
        {
            dialogueManager.NextDialogue();
        }
    }
}