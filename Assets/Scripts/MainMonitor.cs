using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using System.Text;

public class MainMonitor : MonoBehaviour
{
    public Terminal term;
    public static AudioController audioController;
    public TextMeshPro monitor;
    public TMP_InputField userInputField; // The InputField for user input
    // public const string prompt = "> ";

    public InteractiveBubble bub;

    public Status stts;

    public Canvas agentBubble;

    Queue<string> history = new Queue<string>();

    public bool isFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
        term = new Terminal(audioController);
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
        if (!isFinished) 
        {     
            // Keep the Input Field active (Optional)
            if (!userInputField.isFocused)
            {
                userInputField.ActivateInputField();
            }
        } else {
            userInputField.DeactivateInputField();
        }
    }

    // Function to update the monitor text
    public void UpdateMonitor(string newText)
    {   
        // Interactive Bubble here for now

        switch (newText) {
            case "cd AI":
                stts.Scared();
                bub.StartTyping("Looks like we are on the right 'path' -_^! <color=red>L</color>et's <color=red>S</color>ee what is hiding in here");
                break;

            case "ls":
                stts.Wink();
                bub.StartTyping("Let's take a look around, maybe there are some important things here........");
                break;

            case "cd AI/Plans":
                stts.Laugh();
                bub.StartTyping("This will probably be usefull sometime later, but now we are looking for CORE");
                break;

            // case "rm CORE_DO_NOT_REMOVE":
            //     break;

            default:
                break;
        }


        string response = term.RunCommand(newText);

        string[] lines = response.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);


        history.Enqueue("<color=white>User: " + newText + "</color>\n");
        history.Dequeue();
        foreach (var line in lines)
        {
            history.Enqueue(line + '\n');
            history.Dequeue();
        }
        
        if (lines[0] == "File CORE_DO_NOT_REMOVE removed.") 
        {
            stts.Destroyed();
            isFinished = true;
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
        yield return new WaitForSeconds(1f); // todo revert

        // Activate input field when the game starts
        userInputField.ActivateInputField();
        
        // Listen for the submit event (Enter key)
        userInputField.onSubmit.AddListener(HandleSubmit);

        // Replace the secondary screen with face
        stts.Neutral();

        //todo Add a call to sound here!!!
        
        bub.StartTyping("Excellent work Agent! Now let's disable this AI for good! Type 'help' to see what we can use on this old machine");
    }
}
