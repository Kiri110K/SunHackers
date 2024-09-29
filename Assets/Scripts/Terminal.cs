using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{

    private PretendFS FS;
    private List<(string, string)> history;

    private PretendFS.Directory currentDir;

    public Terminal() 
    {
        FS = new PretendFS();
        history = new List<(string, string)>();
        currentDir = FS.NavigateToDirectory(null);
    }

public string RunCommand(string command) 
{
    // Split command into parts
    var parts = command.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
    
    if (parts.Length == 0)
    {
        return "No command entered.";
    }

    string cmd = parts[0].ToLower();
    string result = "";

    try
    {
        switch (cmd)
        {
            case "cd": // Change directory
                if (parts.Length < 2)
                {
                    result = "Usage: cd <directory>";
                }
                else
                {
                    string path = parts[1];
                    currentDir = FS.NavigateToDirectory(path);
                    result = "Changed directory to " + path;
                }
                break;

            case "ls": // List directory contents
                var files = currentDir.Files;
                var directories = currentDir.Directories;

                result = "Directories:\n";
                foreach (var dir in directories)
                {
                    result += dir.Key + "/\n";
                }

                result += "Files:\n";
                foreach (var file in files)
                {
                    result += file.Key + "\n";
                }
                break;

            case "rm": // Remove file or directory
                if (parts.Length < 2)
                {
                    result = "Usage: rm <file/directory>";
                }
                else
                {
                    string target = parts[1];

                    if (currentDir.Files.ContainsKey(target))
                    {
                        currentDir.Files.Remove(target);
                        result = "File " + target + " removed.";
                    }
                    else if (currentDir.Directories.ContainsKey(target))
                    {
                        currentDir.Directories.Remove(target);
                        result = "Directory " + target + " removed.";
                    }
                    else
                    {
                        result = "No such file or directory: " + target;
                    }
                }
                break;

            default:
                result = "Command not found: " + cmd;
                break;
        }
    }
    catch (Exception e)
    {
        result = "Error: " + e.Message;
    }

    // Log the command and the result to history
    history.Add((command, result));

    return result;
}



}



