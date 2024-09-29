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
    // public const string prompt = "> ";
    public Terminal term = new Terminal();

    public InteractiveBubble bub;

    Queue<string> history = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        SetupTerminal(); // Initialize FS, put some files, etc

        // Add 14 "\n" strings to the queue
        for (int i = 0; i < 14; i++)
        {
            history.Enqueue("\n");
        }

        // history.Enqueue("Terminal is now running...\n");


        monitor.text = "";

        // Initialize the text displayed on the monitor
        foreach (var item in history)
        {
            monitor.text += item;
        }
        

        // Set the input field text with the prompt
        // userInputField.text = prompt;

        
        // Set caret blink rate
        userInputField.caretBlinkRate = 0.5f;

        // Set caret width to make it more visible (e.g., 2 pixels wide)
        userInputField.caretWidth = 2;

        // Optionally set caret color (make sure it's visible against your background)
        userInputField.caretColor = Color.white;

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
        // Interactive Bubble here for now

        bub.StartTyping("Hello, I am an interactive text bubble!\nThanks for using unity!!!");


        // Interactive Bubble here for now


        string response = term.RunCommand(newText);

        string[] lines = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);


        history.Enqueue("<color=white>User: " + newText + "</color>\n");
        history.Dequeue();
        foreach (var line in lines)
        {
            history.Enqueue(line + '\n');
            history.Dequeue();
        }
        
        
        StringBuilder sb = new StringBuilder();

        foreach (var item in history)
        {
            sb.Append(item);
        }


        monitor.text = sb.ToString();
    }

    private void SetupTerminal() 
    {
        term.FS.CreateDirectory("","AI"); //todo
        term.FS.CreateDirectory("","OS");
        term.FS.CreateDirectory("", "bin");

        term.FS.CreateFile("AI", "Memories");
        term.FS.CreateFile("AI", "CORE_DO_NOT_REMOVE");
        term.FS.CreateDirectory("AI", "Plans");

        term.FS.CreateFile("OS", "system32");

        term.FS.CreateFile("bin", "PROGRAMS");
    }
}
