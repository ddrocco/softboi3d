using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UnityMain))]
public class UnityMainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        UnityMain myScript = (UnityMain)target;
        if(GUILayout.Button("Construct Genome"))
        {
            myScript.ConstructGenome();
        }
        
        if(GUILayout.Button("Bangarang"))
        {
            myScript.ConstructGenomesAndFuck();
        }
    }
}