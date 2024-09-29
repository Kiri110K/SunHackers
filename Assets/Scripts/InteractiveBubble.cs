using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveBubble : MonoBehaviour
{
    public TextMeshProUGUI bubble;
    public float typingSpeed = 0.05f; // Time between each letter

    private Coroutine typingCoroutine;

    // Call this function to start typing text
    public void StartTyping(string inputText)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(inputText));
    }

    // Coroutine to type text one character at a time
    private IEnumerator TypeText(string inputText)
    {   
        bubble.text = ""; // Clear the existing text
        for (int i = 0; i < inputText.Length; i++)
        {
            bubble.text += inputText[i]; // Add one character at a time
            yield return new WaitForSeconds(typingSpeed); // Wait between characters
        }
        
    }
}
