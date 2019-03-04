using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace Dialogue {
    [CustomNodeEditor(typeof(Chat))]
    public class ChatEditor : NodeEditor {

        public override void OnBodyGUI() {
            serializedObject.Update();

            Chat node = target as Chat;
            if (node.answers.Count == 0) {
                NodeEditorGUILayout.PortPair(target.GetInputPort("input"), target.GetOutputPort("output"));
            } else {
                NodeEditorGUILayout.PortField(target.GetInputPort("input"), GUILayout.Width(100));
            }
            EditorGUILayout.Space();
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("text"));
            NodeEditorGUILayout.InstancePortList("answers", typeof(DialogueBaseNode), serializedObject, NodePort.IO.Output, Node.ConnectionType.Override);

            serializedObject.ApplyModifiedProperties();
        }

        public override int GetWidth() {
            return 400;
        }
    }
}