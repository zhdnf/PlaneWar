using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    Level level;
    Vector2 scrollPos;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        level = target as Level;
        OnRulesGUI(level);
    }

    void OnRulesGUI(Level level)
    {
        GUILayout.Label("Rules:");
        GUILayout.BeginVertical();
        for (int i = 0; i < level.Rules.Count; i++)
        {
            EditorGUILayout.ObjectField(level.Rules[i], typeof(Unit));
        }
        GUILayout.EndVertical();

        if (GUILayout.Button("Add Rule"))
        {
            level.Rules.Add(new SpawnRule());
        }

    }
}
