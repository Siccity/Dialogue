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

            List<DialogueSettings.Item> graphItems = new List<DialogueSettings.Item>();
            if (graph != null && graph.settings.items != null) graphItems = new List<DialogueSettings.Item>(graph.settings.items);

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
                SerializedProperty valueType = item.FindPropertyRelative("value.valueType");

                EditorGUILayout.BeginHorizontal();
                //Remove 
                if (GUILayout.Button("-", GUILayout.Width(20))) {
                    condition.DeleteArrayElementAtIndex(i);
                    i--;
                    continue;
                }
                //key
                int index = graphItems.FindIndex(0, x => x.key == key.stringValue);
                EditorGUI.BeginChangeCheck();
                if (index == -1) index = 0;
                index = EditorGUILayout.Popup(index, graphItems.Select(x => x.key).ToArray());
                if (EditorGUI.EndChangeCheck()) {
                    key.stringValue = graphItems[index].key;
                }

                //Force same type
                ByteValue.ValueType valType = (ByteValue.ValueType) valueType.enumValueIndex;
                if (graphItems[index].value.valueType != valType) valueType.intValue = (int) graphItems[index].value.valueType;

                //Equality
                if (valType != ByteValue.ValueType.Bool) EditorGUILayout.PropertyField(item.FindPropertyRelative("compareMethod"), new GUIContent(), GUILayout.Width(60));
                EditorGUILayout.PropertyField(item.FindPropertyRelative("value"), new GUIContent());
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            if (GUILayout.Button("+", GUILayout.Width(20))) {
                condition.InsertArrayElementAtIndex(condition.arraySize);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();

        }

        public override int GetWidth() {
            return 300;
        }
    }
}