using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;  
    private int dialogueIndex = 0;

    void Start()
    {
        dialogueBox.SetActive(false);
    }

    public void StartDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueIndex = 0;  
        StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {
        if (dialogue.Length == 0) yield break;

        dialogueText.text = "";

        if (dialogueIndex < dialogue.Length)
        {
            foreach (char letter in dialogue[dialogueIndex].ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }

    public void NextDialogue()
    {
        if (dialogueIndex < dialogue.Length - 1)
        {
            dialogueIndex++;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
}