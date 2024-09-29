using System;
using UnityEngine;
using TMPro;

public class ASCII : MonoBehaviour{
    public TextMeshPro textMesh;

    public string printAI(){
        string person = " \\o/\n  |\n / \\";
        return person;
    }

    void Start(){
        textMesh.text = printAI();
    }

    void Update(){
    }
}
