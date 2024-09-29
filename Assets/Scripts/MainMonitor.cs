using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using System.Text;

public class MainMonitor : MonoBehaviour
{
    public TextMeshPro monitor;
    public TMP_InputField userInputField; // The InputField for user input
    public const string prompt = "> ";

    Queue<string> history = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        // Add 14 "\n" strings to the queue
        for (int i = 0; i < 13; i++)
        {
            history.Enqueue("\n");
        }

        history.Enqueue("Terminal is now running...\n");


        monitor.text = "";
        // Initialize the text displayed on the monitor
        foreach (var item in history)
        {
            monitor.text += item;
        }
        

        // Set the input field text with the prompt
        // userInputField.text = prompt;

        // Activate input field when the game starts
        userInputField.ActivateInputField();

        // Listen for the submit event (Enter key)
        userInputField.onSubmit.AddListener(HandleSubmit);
    }

    void HandleSubmit(string submittedText)
    {
        // Move the input text to the history quad's TextMeshPro
        UpdateMonitor(submittedText);

        // // Clear the input field after Enter is pressed
        // userInputField.text = prompt;
        // Clear the input field after Enter is pressed
        userInputField.text = string.Empty;

        // Reactivate the input field for further typing
        userInputField.ActivateInputField();
    }


    // Update is called once per frame
    void Update()
    {        
        // Keep the Input Field active (Optional)
        if (!userInputField.isFocused)
        {
            userInputField.ActivateInputField();
        }
    }

    // Function to update the monitor text
    public void UpdateMonitor(string newText)
    {
        
        history.Enqueue(newText + "\n");
        history.Dequeue();
        
        
        StringBuilder sb = new StringBuilder();

        foreach (var item in history)
        {
            sb.Append(item);
        }


        monitor.text = sb.ToString();
    }
}
