using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace Dialogue {
    [CustomNodeEditor(typeof(Chat))]
    public class ChatEditor : NodeEditor {

        public override void OnBodyGUI() {
            Chat dialogue = target as Chat;
            GUILayout.BeginHorizontal();
            NodeEditorGUILayout.PortField(target.GetInputPort("input"), GUILayout.Width(100));
            EditorGUILayout.Space();
            if (dialogue.answers.Count == 0) NodeEditorGUILayout.PortField(target.GetOutputPort("output"), GUILayout.Width(100));
            GUILayout.EndHorizontal();
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("text"));

            for (int i = 0; i < dialogue.answers.Count; i++) {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("-", GUILayout.Width(30))) {
                    target.RemoveInstancePort(dialogue.answers[i].portName);
                    dialogue.answers.RemoveAt(i);
                    i--;
                }
                dialogue.answers[i].text = EditorGUILayout.TextField(dialogue.answers[i].text);
                NodeEditorGUILayout.PortField(new GUIContent(), target.GetOutputPort(dialogue.answers[i].portName), GUILayout.Width(-4));
                GUILayout.EndHorizontal();
            }
            GUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            if (GUILayout.Button("+", GUILayout.Width(30))) {
                NodePort newport = target.AddInstanceOutput(typeof(Chat.Connection));
                dialogue.answers.Add(new Chat.Answer() { text = "", portName = newport.fieldName });
            }
            GUILayout.EndHorizontal();
        }

        public override int GetWidth() {
            return 400;
        }
    }
}