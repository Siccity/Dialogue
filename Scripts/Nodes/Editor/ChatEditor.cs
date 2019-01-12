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
            NodeEditorGUILayout.InstancePortList("answers", typeof(Chat.Answer), serializedObject, NodePort.IO.Output, Node.ConnectionType.Override);
        }

        public override int GetWidth() {
            return 400;
        }
    }
}