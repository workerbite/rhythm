using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(MapTool))]
public class EditorMaptool : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapTool t = (MapTool)target;

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("DK"))
        {
            t.ButtonCreateBlock(BlockModel.Type.DK);

        }

        if (GUILayout.Button("DS1"))
        {
            t.ButtonCreateBlock(BlockModel.Type.DS1);
        }

        if (GUILayout.Button("DS2"))
        {
            t.ButtonCreateBlock(BlockModel.Type.DS2);
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("DSK"))
        {
            t.ButtonCreateBlock(BlockModel.Type.DSK);
        }


        if (GUILayout.Button("GR"))
        {
            t.ButtonCreateBlock(BlockModel.Type.GR);
        }


        if (GUILayout.Button("KI"))
        {
            t.ButtonCreateBlock(BlockModel.Type.KI);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("PO1"))
        {
            t.ButtonCreateBlock(BlockModel.Type.PO1);
        }

        if (GUILayout.Button("PO2"))
        {
            t.ButtonCreateBlock(BlockModel.Type.PO2);
        }


        if (GUILayout.Button("PO3"))
        {
            t.ButtonCreateBlock(BlockModel.Type.PO3);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("PO4"))
        {
            t.ButtonCreateBlock(BlockModel.Type.PO4);
        }


        if (GUILayout.Button("SK"))
        {
            t.ButtonCreateBlock(BlockModel.Type.SK);
        }

        if (GUILayout.Button("SN"))
        {
            t.ButtonCreateBlock(BlockModel.Type.SN);
        }

        if (GUILayout.Button("HA"))
        {
            t.ButtonCreateBlock(BlockModel.Type.HA);

        }

        if (GUILayout.Button("DH"))
        {
            t.ButtonCreateBlock(BlockModel.Type.DH);

        }

        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Clear"))
        {
            t.ButtonClear();
        }


        if (GUILayout.Button("Save"))
        {
            t.ButtonSave();
        }

        if (GUILayout.Button("Load"))
        {
            t.ButtonLoad();
        }


    }
}
