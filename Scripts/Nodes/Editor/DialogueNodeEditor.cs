using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace Dialogue {
    [CustomNodeEditor(typeof(DialogueNode))]
    public class DialogueNodeEditor : NodeEditor {

        public override void OnBodyGUI() {
            DialogueNode dialogue = target as DialogueNode;
            GUILayout.BeginHorizontal();
            NodeEditorGUILayout.PortField(target.GetInputPort("input"));
            if (dialogue.answers.Count == 0) NodeEditorGUILayout.PortField(target.GetOutputPort("output"));
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
                NodePort newport = target.AddInstanceOutput(typeof(DialogueNode.Connection));
                dialogue.answers.Add(new DialogueNode.Answer() { text = "", portName = newport.fieldName });
            }
            GUILayout.EndHorizontal();
        }

        public override int GetWidth() {
            return 400;
        }
    }
}