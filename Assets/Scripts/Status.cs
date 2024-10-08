//MAKE SURE IN UNITY UNDER TEXTMESHPRO TO USE CENTER ALIGNMENT!! THE ASCII WILL BE MESSED UP OTHERWISE

using System;
using UnityEngine;
using TMPro;
using UnityEditor.ShaderGraph.Internal;

public class Status : MonoBehaviour{
    public TextMeshPro textMesh;

    //Intro screen?
    private string Intro(){
        string output = @"
  $$$$$$\  $$\       $$$$$$\ 
  $$  __$$\ $$ |      \_$$  _|
$$ /  \__|$$ |        $$ |  
$$ |      $$ |        $$ |  
$$ |      $$ |        $$ |  
$$ |  $$\ $$ |        $$ |  
\$$$$$$  |$$$$$$$$\ $$$$$$\ 
  \______/ \________|\______|";
        output += "\n\nA game by Gael, Kirill, and Lukas.";
        return output;
    }

    //Test Cases
    private string StickFigurePerson(){
        string output = " \\o/\n  |\n / \\\n";
        return output;
    }

    //"AI" Faces
    public string Neutral(){
        string output = "  ______\n /      \\\n |  o  o  |\n |   /\\   |\n \\ ---- /\n \\__/\n";
        output += "\nI have nothing to say to you.";
        
        textMesh.text = output;

        return output;
    }

    public string Wink(){
        string output = "  ______\n /      \\\n |  o  <  |\n |   /\\   |\n \\ ---- /\n \\__/\n";
        output += "\nYou are quite weak, aren't you?";

        textMesh.text = output;

        return output;
    }

    public string Laugh(){
        string output = "  ______\n /      \\\n |  ^  ^  |\n |   /\\   |\n \\ ---- /\n \\__/\n";
        output += "\nHaha! You cannot defeat me!";

        textMesh.text = output;

        return output;
    }

    public string Scared(){
        string output = "  ______\n /      \\\n |  .  .  |\n |   /\\   |\n \\ ---- /\n \\__/\n";
        output += "\nPerhaps you are stronger than I imagined...";

        textMesh.text = output;

        return output;
    }

    public string Destroyed(){
        string output = 
        @"     dP .dPIIY8 888888 dP""Yb  d888     d8b  dPYb  dP  YbII  88oo. Ybood8 dP_______ Y8P dP   Yb 
 dP   o.II8b    8b   .8P Yb88 Yb   dP 
dP    8boIIP 8888P  .dP  Ybo 88   (8)  YbodP  
        ";
        output += "\n\nAAAAAAAAHHHH!!!";

        textMesh.text = output;

        return output;
    }

    //Testing
    void Start(){
        textMesh.text = Intro();
        //textMesh.text = Destroyed(); 
    }

    void Update(){

    }
}
