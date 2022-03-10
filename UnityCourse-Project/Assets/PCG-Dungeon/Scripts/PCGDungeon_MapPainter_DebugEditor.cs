using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PCGDungeon
{
    
    [CustomEditor(typeof(PCGDungeon_MapPainter))]
    public class PCGDungeon_MapPainter_DebugEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            PCGDungeon_MapPainter mapPainter = (PCGDungeon_MapPainter)target;
            if (GUILayout.Button("Random Walk Generate"))
            {
                mapPainter.RandomWalkGenerate();
            }
        }

    }
}
