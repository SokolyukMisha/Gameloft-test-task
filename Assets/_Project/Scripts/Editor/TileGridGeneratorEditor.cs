using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileGridGenerator))]
public class TileGridGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUILayout.Space(8f);
        EditorGUILayout.HelpBox("Spawns tiles in Edit Mode with 2-unit spacing.", MessageType.Info);

        TileGridGenerator generator = (TileGridGenerator)target;

        using (new EditorGUI.DisabledScope(Application.isPlaying))
        {
            if (GUILayout.Button("\u0421\u0433\u0435\u043d\u0435\u0440\u0438\u0440\u043e\u0432\u0430\u0442\u044c \u0441\u0435\u0442\u043a\u0443", GUILayout.Height(32f)))
            {
                generator.GenerateGridInEditor();
            }

            if (GUILayout.Button("\u041e\u0447\u0438\u0441\u0442\u0438\u0442\u044c \u0441\u0435\u0442\u043a\u0443", GUILayout.Height(24f)))
            {
                generator.ClearGridInEditor();
            }
        }
    }
}
