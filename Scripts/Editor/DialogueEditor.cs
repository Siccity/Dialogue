using System.Collections;
using System.Collections.Generic;
using Dialogue;
using UnityEditor;
using UnityEngine;

namespace DialogueEditor {
    [CustomEditor(typeof(DialogueGraph))]
    public class DialogueEditor : Editor {

        public override void OnInspectorGUI() {
			EditorGUILayout.PropertyField(serializedObject.FindProperty("settings"), true);
		}
    }
}