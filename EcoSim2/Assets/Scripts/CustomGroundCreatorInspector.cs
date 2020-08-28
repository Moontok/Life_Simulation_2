using UnityEditor;
using UnityEngine;
using System;

[CustomEditor(typeof(GroundCreator))]
public class CustomGroundCreatorInspector : Editor
{
    GroundCreator creator;
    SerializedProperty autoUpdate;
    SerializedProperty tiles;

    void OnEnable() 
    {
        creator = target as GroundCreator;
        autoUpdate = serializedObject.FindProperty("autoUpdate");
        tiles = serializedObject.FindProperty("tiles");
        
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();
        for (int i = 0; i < tiles.arraySize; i++)
        {
            EditorGUILayout.Slider("Band "+i, 0, 0, 1);
            
        }

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
