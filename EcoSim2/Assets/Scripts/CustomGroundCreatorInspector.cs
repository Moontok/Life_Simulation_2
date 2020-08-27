using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GroundCreator))]
public class CustomGroundCreatorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GroundCreator creator = (GroundCreator)target;
        // if(GUILayout.Button("Create Land"))
        // {
        //     creator.GenerateLand();
        // }

        // EditorGUILayout.LabelField("Delete");
        
        // if(GUILayout.Button("Delete Land"))
        // {
        //     creator.DeleteLand();
        // }
    }
}
