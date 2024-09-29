using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMonitor : MonoBehaviour
{
    public TextMeshPro monitor;
    public TMP_InputField userInputField; // The InputField for user input

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the text displayed on the monitor
        monitor.text = "Terminal is now running...";
        
        // Activate input field when the game starts
        userInputField.ActivateInputField();
    }

    // Update is called once per frame
    
    int textCounter = 1;
    void Update()
    {        
        // Keep the Input Field active (Optional)
        if (!userInputField.isFocused)
        {
            userInputField.ActivateInputField();
        }
    }

    void FixedUpdate() 
    {
            UpdateMonitor(textCounter.ToString());
            textCounter += 1;
    }

        // Function to update the monitor text
    public void UpdateMonitor(string newText)
    {
        monitor.text = newText;
    }
}
