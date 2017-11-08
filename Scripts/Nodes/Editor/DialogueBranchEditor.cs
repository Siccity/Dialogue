using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Dialogue;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

namespace DialogueEditor {
    [CustomNodeEditor(typeof(DialogueBranch))]
    public class DialogueBranchEditor : NodeEditor {
        public override void OnBodyGUI() {
            DialogueBranch branch = target as DialogueBranch;
            DialogueGraph graph = branch.graph as DialogueGraph;
            List<string> labels = graph.settings.items.Select(x => x.key).ToList();

            EditorGUILayout.BeginHorizontal();
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("input"), true);
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("pass"), true);
            EditorGUILayout.EndHorizontal();
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("fail"), true);

            EditorGUILayout.BeginVertical("Box");
			EditorGUILayout.LabelField("Conditions");
            SerializedProperty condition = serializedObject.FindProperty("condition");
            for (int i = 0; i < condition.arraySize; i++) {
                SerializedProperty item = condition.FindPropertyRelative("Array.data[" + i + "]");
                SerializedProperty key = item.FindPropertyRelative("key");
                SerializedProperty value = item.FindPropertyRelative("value.bytes");

                Rect r = GUILayoutUtility.GetRect(new GUIContent(" "), new GUIStyle(), GUILayout.Height(EditorGUIUtility.singleLineHeight));
                float width = r.width;
				r.width = width * 0.4f;
                int index = labels.IndexOf(key.stringValue);
                EditorGUI.BeginChangeCheck();
                if (index == -1) index = 0;
                index = EditorGUI.Popup(r, index, labels.ToArray());
                if (EditorGUI.EndChangeCheck()) {
                    key.stringValue = labels[index];
                }
                r.x += r.width;
				r.width = width * 0.2f;
				EditorGUI.PropertyField(r, item.FindPropertyRelative("compareMethod"), new GUIContent());

                r.x += r.width;
				r.width = width * 0.4f;
				EditorGUI.PropertyField(r, item.FindPropertyRelative("value"), new GUIContent());
            }
            EditorGUILayout.EndVertical();

        }

        public override int GetWidth() {
            return 250;
        }
    }
}