using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PretendFS : MonoBehaviour
{
    public class File
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public File(string name)
        {
            Name = name;
            Content = string.Empty;
        }

        // Write content to the file
        public void Write(string content)
        {
            Content = content;
        }

        public void Append(string content)
        {
            Content += content;
        }

        // Read content from the file
        public string Read()
        {
            return Content;
        }
    }

    // Simulates a Directory containing files and subdirectories
    public class Directory
    {
        public string Name { get; }
        public Dictionary<string, File> Files { get; }
        public Dictionary<string, Directory> Directories { get; }

        public Directory(string name)
        {
            Name = name;
            Files = new Dictionary<string, File>();
            Directories = new Dictionary<string, Directory>();
        }

        // Create a file in the directory
        public File CreateFile(string fileName)
        {
            if (!Files.ContainsKey(fileName))
            {
                var newFile = new File(fileName);
                Files[fileName] = newFile;
                return newFile;
            }
            throw new Exception("File already exists");
        }

        // Get a file from the directory
        public File GetFile(string fileName)
        {
            if (Files.ContainsKey(fileName))
                return Files[fileName];
            throw new Exception("File not found");
        }

        // Create a subdirectory
        public Directory CreateDirectory(string dirName)
        {
            if (!Directories.ContainsKey(dirName))
            {
                var newDir = new Directory(dirName);
                Directories[dirName] = newDir;
                return newDir;
            }
            throw new Exception("Directory already exists");
        }

        // Get a subdirectory
        public Directory GetDirectory(string dirName)
        {
            if (Directories.ContainsKey(dirName))
                return Directories[dirName];
            throw new Exception("Directory not found");
        }
    }


    // Main pretend filesystem class
        private Directory root;

        public PretendFS()
        {
            root = new Directory("root");
        }

        // Create a file at a given path
        public void CreateFile(string path, string fileName)
        {
            var dir = NavigateToDirectory(path);
            dir.CreateFile(fileName);
        }

        // Write content to a file
        public void WriteToFile(string path, string fileName, string content)
        {
            var dir = NavigateToDirectory(path);
            var file = dir.GetFile(fileName);
            file.Write(content);
        }

        // Read content from a file
        public string ReadFromFile(string path, string fileName)
        {
            var dir = NavigateToDirectory(path);
            var file = dir.GetFile(fileName);
            return file.Read();
        }

        // Create a directory at a given path
        public void CreateDirectory(string path, string dirName)
        {
            var dir = NavigateToDirectory(path);
            dir.CreateDirectory(dirName);
        }

        // Navigate to a directory based on path
        private Directory NavigateToDirectory(string path)
        {
            var currentDir = root;
            if (string.IsNullOrEmpty(path) || path == "/")
                return currentDir;

            var parts = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                currentDir = currentDir.GetDirectory(part);
            }

            return currentDir;
        }
    
}
