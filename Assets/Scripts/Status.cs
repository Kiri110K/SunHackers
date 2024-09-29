using System;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour{
    public TextMeshPro textMesh;

    private string person(){
        string person = " \\o/\n  |\n / \\\n";
        return person;
    }

    private string happyFace(){
        string person = " ^  ^\n\\____/\n";
        return person;
    }

    //private string 

    void Start(){
        textMesh.text = person();
        //textMesh.text = happyFace();
        //textMesh.text = 
    }

    void Update(){

    }
}
