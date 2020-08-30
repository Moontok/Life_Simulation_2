using UnityEditor;
using UnityEngine;
using System;

[CustomEditor(typeof(GroundCreator))]
public class CustomGroundCreatorInspector : Editor
{
    GroundCreator creator;
    SerializedProperty autoUpdate;

    void OnEnable() 
    {
        creator = target as GroundCreator;
        autoUpdate = serializedObject.FindProperty("autoUpdate");        
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();

        using (new EditorGUI.DisabledScope(autoUpdate.boolValue))
        {
            if(GUILayout.Button("Generate Land"))
            {
                creator.GenerateLand();
            }
            if(GUILayout.Button("Delete Land"))
            {
                creator.DeleteLand();
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
