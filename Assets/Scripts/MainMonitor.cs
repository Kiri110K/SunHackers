using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMonitor : MonoBehaviour
{
    public TextMeshPro monitor;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the text displayed on the monitor
        monitor.text = "Terminal is now running...";
    }

    // Update is called once per frame
    int counter = 0;
    int textCounter = 1;
    void Update()
    {
        counter += 1;
        counter %= 30;
        if (counter == 29) {
            UpdateMonitor(textCounter.ToString());
            textCounter += 1;
        }
    }

        // Function to update the monitor text
    public void UpdateMonitor(string newText)
    {
        monitor.text = newText;
    }
}
