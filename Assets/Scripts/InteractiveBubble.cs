using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InteractiveBubble : MonoBehaviour
{
    public Canvas agentBubble;
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

        Debug.Log("Statring typing coroutine\n");
        typingCoroutine = StartCoroutine(RingAndTalkAndType(inputText));
    }

    // Coroutine to type text one character at a time
    private IEnumerator TypeText(string inputText)
    {   
        
        bubble.text = ""; // Clear the existing text
        agentBubble.enabled = true; // Be sure that agent is active when starts typing

        for (int i = 0; i < inputText.Length; i++)
        {
            bubble.text += inputText[i]; // Add one character at a time
            yield return new WaitForSeconds(typingSpeed); // Wait between characters
        }
        
        Debug.Log("Finished typing");

        yield return new WaitForSeconds(2f); // Wait for some time before hiding the bubble
        agentBubble.enabled = false;
    }

    // Coroutine to handle ringing and talking
    private IEnumerator RingAndTalkAndType(string inputText)
    {   
        // todo add ringing
        Debug.Log("Should have started ringing");
        yield return new WaitForSeconds(1.5f); // todo change to a length of ringing sound


        Debug.Log("Should have finished ringing");
        // todo add talking
        
        Debug.Log("Started typing");
        TypeText(inputText);
    }
}
