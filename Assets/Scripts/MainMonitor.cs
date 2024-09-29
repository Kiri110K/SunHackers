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

    public Status stts;

    public GameObject agentBubble;

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

        monitor.text = "";

        // Initialize the text displayed on the monitor
        foreach (var item in history)
        {
            monitor.text += item;
        }
        StartCoroutine(PauseCoroutine());
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

    // Coroutine for pausing
    private IEnumerator PauseCoroutine()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Activate input field when the game starts
        userInputField.ActivateInputField();
        
        // Listen for the submit event (Enter key)
        userInputField.onSubmit.AddListener(HandleSubmit);

        // Replace the secondary screen with face
        stts.Neutral();

        //todo Add a call to sound here!!!
        agentBubble.SetActive(true);
    }
}
